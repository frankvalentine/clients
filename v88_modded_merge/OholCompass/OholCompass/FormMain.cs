using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace OholCompass
{
    public partial class FormMain : Form
    {
        #region Constants

        const string PlayerUpdateMessage = "Got first PLAYER_UPDATE message, our ID = ";

        #endregion

        #region Member Fields

        bool init = false;
        bool changed = false;
        bool shouldSimulate = false;
        List<Destination> destinations = new List<Destination>();
        string outputPath;
        int ourid;
        int sx;
        int sy;
        bool lastpm;
        bool lastpu;
        Dictionary<int, Tuple<int, int>> lastpudata = new Dictionary<int, Tuple<int, int>>();

        #endregion

        #region Constructor

        public FormMain()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Properties.Settings.Default.OholPath))
            {
                MessageBox.Show("You need to set a path to your OHOL folder.");
                SetControlVisibility(false);
                return;
            }

            Init();
        }

        #endregion

        #region Methods

        private void SetControlVisibility(bool shown)
        {
            groupBox1.Visible = shown;
            groupBox2.Visible = shown;
        }

        private void Init()
        {
            TextOholPath.Text = Properties.Settings.Default.OholPath;
            LoadBookmarks();
            SetDoubleBuffered(compass1);
            //outputPath = GetOutputPath();
            outputPath = Path.Combine(Properties.Settings.Default.OholPath, "stdout.txt");
            txtCurrentX.Text = "NaN";
            txtCurrentY.Text = "NaN";
            txtTargetX.Text = "0";
            txtTargetY.Text = "0";
            lstBookmarks.HideSelection = false;

            if (shouldSimulate)
            {
                SimulateMessages();
            }
            else
            {
                //HandleMessages(GetOutputPath());
                HandleMessages(outputPath);
            }

            init = true;
        }

        private void LoadBookmarks()
        {
            try
            {
                using (var xmlReader = XmlReader.Create("bookmarks.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<Destination>));
                    destinations = (List<Destination>)serializer.Deserialize(xmlReader);
                    foreach (var dest in destinations)
                    {
                        var item = new ListViewItem(dest.Name)
                        {
                            ForeColor = (dest.Color == Color.White) ? Color.Black : Color.White,
                            BackColor = dest.Color
                        };
                        item.Name = item.Text;
                        item.SubItems.Add(dest.X.ToString());
                        item.SubItems.Add(dest.Y.ToString());
                        lstBookmarks.Items.Add(item);
                    }
                }
            }
            catch
            {
            }
        }

        private void SaveBookmarks()
        {
            try
            {
                using (var xmlWriter = XmlWriter.Create("bookmarks.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<Destination>));
                    serializer.Serialize(xmlWriter, destinations);
                }
            }
            catch
            {
            }
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo aProp =
                  typeof(Control).GetProperty("DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        public static string DegreesToCardinal(double degrees)
        {
            string[] cardinals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
            return cardinals[(int)Math.Round(((double)degrees % 360) / 45)];
        }

        //public static string GetOutputPath()
        //{
        //    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneLife");
        //    return Path.Combine(path, "stdout.txt");
        //}

        private void ParseMessage(string line)
        {
            line = line.Trim();

            if (lastpu)
            {
                try
                {
                    string[] parts = line.Split(' ');

                    int.TryParse(parts[0], out int key);
                    if (key == 0) return;

                    int.TryParse(parts[14], out int x);
                    int.TryParse(parts[15], out int y);

                    lastpudata[key] = new Tuple<int, int>(x, y);
                    Debug.WriteLine(string.Format("[PU] ID: {0} XY: ( {1}, {2} )", key, x, y));
                }
                catch (Exception)
                {
                    lastpu = false;
                    Debug.WriteLine("[PU] Exception");
                }
            }
            else
            {
                if (lastpm)
                {
                    try
                    {
                        if (ourid == 0 || line.StartsWith(ourid.ToString() + " "))
                        {
                            string[] parts = line.Split(' ');
                            int ox = sx = Convert.ToInt32(parts[1]);
                            int oy = sy = Convert.ToInt32(parts[2]);

                            int dx=0, dy=0;
                            if (parts.Length > 6)
                            {
                                dx = Convert.ToInt32(parts[parts.Length - 2]);
                                dy = Convert.ToInt32(parts[parts.Length - 1]);
                                sx += dx;
                                sy += dy;
                            }

                            lastpm = false;

                            Debug.WriteLine(string.Format("[PM] O( {0}, {1} ) + D ( {2}, {3} ) = S ( {4}, {5} )", ox, oy, dx, dy, sx, sy));
                        }
                    }
                    catch
                    {
                        lastpm = false;
                    }
                }
                else
                {
                    if (line.StartsWith(PlayerUpdateMessage))
                    {
                        string idstring = line.Substring(42);
                        ourid = Convert.ToInt32(idstring);

                        if (lastpudata.ContainsKey(ourid))
                        {
                            sx = lastpudata[ourid].Item1;
                            sy = lastpudata[ourid].Item2;
                            Debug.WriteLine(string.Format("[PUPDATE] ID: {0} S: ( {1}, {2} )", ourid, sx, sy));
                        }
                        else
                        {
                        }
                    }
                }

                lastpm = line == "PM";
            }

            if (line == "PU")
            {
                lastpudata.Clear();
                lastpu = true;
            }
            else
            {
                lastpu = false;
            }
        }

        delegate void UpdateTextboxDelegate(TextBox txt, string text);
        private void SetText(TextBox txt, string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateTextboxDelegate(SetText), txt, text);
                return;
            }
            else
            {
                txt.Text = text;
            }
        }

        private void HandleMessages(string path)
        {
            var monitor = new LogFileMonitor(path, "\r\n");

            monitor.OnLine += (s, e) =>
            //monitor.OnLines += (s, e) =>
            {
                ParseMessage(e.Line);

                //foreach (var line in e.Lines)
                //{
                //    Debug.WriteLine(line);
                //    ParseMessage(line);
                //}

                compass1.CurrentX = sx;
                compass1.CurrentY = sy;
                SetText(txtCurrentX, sx.ToString());
                SetText(txtCurrentY, sy.ToString());
            };
            monitor.Start();
        }

        private void SimulateMessages()
        {
            sx = 195698;
            sy = 61721;
            SetText(txtCurrentX, sx.ToString());
            SetText(txtCurrentY, sy.ToString());
            compass1.CurrentX = 195698;
            compass1.CurrentY = 61721;
        }

        private void AddNewBookmark()
        {
            if (string.IsNullOrEmpty(txtBookmarkX.Text) || string.IsNullOrEmpty(txtBookmarkName.Text) || string.IsNullOrEmpty(txtBookmarkY.Text)) return;

            if (lstBookmarks.Items.ContainsKey(txtBookmarkName.Text)) return;

            var item = new ListViewItem(txtBookmarkName.Text)
            {
                //ForeColor = (btnBookmarkColor.BackColor == Color.White) ? Color.Black : Color.White,
                //BackColor = btnBookmarkColor.BackColor
            };

            item.Name = txtBookmarkName.Text;
            item.SubItems.Add(txtBookmarkX.Text);
            item.SubItems.Add(txtBookmarkY.Text);

            lstBookmarks.Items.Add(item);

            foreach (var dest in destinations)
            {
                if (dest.Name == txtBookmarkName.Text)
                {
                    dest.Name = txtBookmarkName.Text;
                    dest.X = Convert.ToInt32(txtBookmarkX.Text);
                    dest.Y = Convert.ToInt32(txtBookmarkY.Text);
                    changed = true;
                    return;
                }
            }

            destinations.Add(new Destination() { Name = txtBookmarkName.Text, X = Convert.ToInt32(txtBookmarkX.Text), Y = Convert.ToInt32(txtBookmarkY.Text) });
            changed = true;
        }

        #endregion

        #region Event Handlers

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / 30;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            compass1.Invalidate();
        }

        private void BtnAddToBookmarks_Click(object sender, EventArgs e)
        {
            AddNewBookmark();
        }

        private void BtnRemoveFromBookmarks_Click(object sender, EventArgs e)
        {
            var selectedItems = lstBookmarks.SelectedItems;
            if (selectedItems.Count > 0)
            {
                var item = selectedItems[0];

                for(int i=0; i < destinations.Count; i++)
                {
                    if (destinations[i].Name == item.Text)
                    {
                        destinations.RemoveAt(i);
                        break;
                    }
                }

                lstBookmarks.Items.Remove(item);

                if (lstBookmarks.Items.Count > 0)
                {
                    lstBookmarks.Items[0].Selected = true;
                }
                else
                {
                    txtBookmarkName.Text = "";
                    txtBookmarkX.Text = "";
                    txtBookmarkY.Text = "";
                }
            }
            else
            {
                txtBookmarkName.Text = "";
                txtBookmarkX.Text = "";
                txtBookmarkY.Text = "";
            }

            changed = true;
        }

        private void LstBookmarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItems = lstBookmarks.SelectedItems;
            if (selectedItems.Count > 0)
            {
                var item = selectedItems[0];
                txtBookmarkName.Text = item.Text;

                if (item.SubItems.Count == 3)
                {
                    txtTargetName.Text = item.Text;
                    txtBookmarkX.Text = item.SubItems[1].Text;
                    txtBookmarkY.Text = item.SubItems[2].Text;

                    compass1.CurrentX = sx;
                    compass1.CurrentY = sy;
                    txtTargetX.Text = sx.ToString();
                    txtTargetY.Text = sy.ToString();
                    compass1.TargetDestination = new Destination() { Name=item.Text, Color=item.BackColor, X=Convert.ToInt32(item.SubItems[1].Text), Y= Convert.ToInt32(item.SubItems[2].Text) };
                }
                else
                {
                    txtTargetName.Text = "";
                    txtBookmarkX.Text = "0";
                    txtBookmarkY.Text = "0";
                    compass1.TargetDestination = null;
                }
            }
        }

        private void LstDestinations_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TxtBookmarkX_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtBookmarkY_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtBookmarkName_TextChanged(object sender, EventArgs e)
        {
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed) return;
            DialogResult dr = MessageBox.Show("Save changes?", "Exiting", MessageBoxButtons.YesNoCancel);

            switch (dr)
            {
                case DialogResult.Yes:
                    SaveBookmarks();
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void LstBookmarks_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                if (lstBookmarks.FocusedItem == null)
                {
                    grpBookmarkProperties.Visible = false;
                }
                else
                {
                    grpBookmarkProperties.Visible = lstBookmarks.FocusedItem.Selected;
                }
            }*/
        }

        private void BtnCreateBookmark_Click(object sender, EventArgs e)
        {
            txtBookmarkName.Text = txtCustomBookmarkName.Text;
            txtBookmarkX.Text = txtCurrentX.Text;
            txtBookmarkY.Text = txtCurrentY.Text;
            AddNewBookmark();
            txtCustomBookmarkName.Text = "";
        }

        private void TxtCurrentX_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentX.Text) || txtCurrentX.Text == "NaN") return;
            compass1.CurrentX = Convert.ToInt32(txtCurrentX.Text);
            compass1.Invalidate();
        }

        private void TxtCurrentY_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentY.Text) || txtCurrentY.Text == "NaN") return;
            compass1.CurrentY = Convert.ToInt32(txtCurrentY.Text);
            compass1.Invalidate();
        }

        private void BtnChooseOholPath_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fd.SelectedPath))
                {
                    TextOholPath.Text = fd.SelectedPath;
                    Properties.Settings.Default.OholPath = fd.SelectedPath;
                    Properties.Settings.Default.Save();

                    if (!init)
                    {
                        SetControlVisibility(true);
                        Init();
                    }
                }
            }
        }

        #endregion
    }
}
