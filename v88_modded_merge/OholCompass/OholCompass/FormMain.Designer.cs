namespace OholCompass
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomBookmarkName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCreateBookmark = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTargetName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentY = new System.Windows.Forms.TextBox();
            this.txtCurrentX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.compass1 = new OholCompass.Compass();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetY = new System.Windows.Forms.TextBox();
            this.txtTargetX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpBookmarkProperties = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddToBookmarks = new System.Windows.Forms.Button();
            this.txtBookmarkX = new System.Windows.Forms.TextBox();
            this.txtBookmarkY = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBookmarkName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemoveFromBookmarks = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lstBookmarks = new System.Windows.Forms.ListView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.BtnChooseOholPath = new System.Windows.Forms.Button();
            this.TextOholPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBookmarkProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomBookmarkName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnCreateBookmark);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtTargetName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCurrentY);
            this.groupBox1.Controls.Add(this.txtCurrentX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.compass1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTargetY);
            this.groupBox1.Controls.Add(this.txtTargetX);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 515);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compass";
            // 
            // txtCustomBookmarkName
            // 
            this.txtCustomBookmarkName.Location = new System.Drawing.Point(12, 488);
            this.txtCustomBookmarkName.Name = "txtCustomBookmarkName";
            this.txtCustomBookmarkName.Size = new System.Drawing.Size(299, 20);
            this.txtCustomBookmarkName.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 472);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Bookmark Name:";
            // 
            // btnCreateBookmark
            // 
            this.btnCreateBookmark.Location = new System.Drawing.Point(87, 442);
            this.btnCreateBookmark.Name = "btnCreateBookmark";
            this.btnCreateBookmark.Size = new System.Drawing.Size(176, 23);
            this.btnCreateBookmark.TabIndex = 35;
            this.btnCreateBookmark.Text = "Create Bookmark";
            this.btnCreateBookmark.UseVisualStyleBackColor = true;
            this.btnCreateBookmark.Click += new System.EventHandler(this.BtnCreateBookmark_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Target Name";
            // 
            // txtTargetName
            // 
            this.txtTargetName.Location = new System.Drawing.Point(6, 115);
            this.txtTargetName.Name = "txtTargetName";
            this.txtTargetName.ReadOnly = true;
            this.txtTargetName.Size = new System.Drawing.Size(315, 20);
            this.txtTargetName.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Target Coordinates:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "X";
            // 
            // txtCurrentY
            // 
            this.txtCurrentY.Location = new System.Drawing.Point(190, 408);
            this.txtCurrentY.Name = "txtCurrentY";
            this.txtCurrentY.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentY.TabIndex = 22;
            this.txtCurrentY.TextChanged += new System.EventHandler(this.TxtCurrentY_TextChanged);
            // 
            // txtCurrentX
            // 
            this.txtCurrentX.Location = new System.Drawing.Point(63, 408);
            this.txtCurrentX.Name = "txtCurrentX";
            this.txtCurrentX.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentX.TabIndex = 21;
            this.txtCurrentX.TextChanged += new System.EventHandler(this.TxtCurrentX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Current Coordinates:";
            // 
            // compass1
            // 
            this.compass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compass1.CurrentX = 0;
            this.compass1.CurrentY = 0;
            this.compass1.Location = new System.Drawing.Point(55, 151);
            this.compass1.Name = "compass1";
            this.compass1.Size = new System.Drawing.Size(216, 216);
            this.compass1.TabIndex = 17;
            this.compass1.TargetDestination = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            // 
            // txtTargetY
            // 
            this.txtTargetY.Location = new System.Drawing.Point(190, 65);
            this.txtTargetY.Name = "txtTargetY";
            this.txtTargetY.Size = new System.Drawing.Size(100, 20);
            this.txtTargetY.TabIndex = 14;
            // 
            // txtTargetX
            // 
            this.txtTargetX.Location = new System.Drawing.Point(63, 65);
            this.txtTargetX.Name = "txtTargetX";
            this.txtTargetX.Size = new System.Drawing.Size(100, 20);
            this.txtTargetX.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpBookmarkProperties);
            this.groupBox2.Controls.Add(this.btnRemoveFromBookmarks);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lstBookmarks);
            this.groupBox2.Location = new System.Drawing.Point(345, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 515);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Navigation";
            // 
            // grpBookmarkProperties
            // 
            this.grpBookmarkProperties.Controls.Add(this.label10);
            this.grpBookmarkProperties.Controls.Add(this.btnAddToBookmarks);
            this.grpBookmarkProperties.Controls.Add(this.txtBookmarkX);
            this.grpBookmarkProperties.Controls.Add(this.txtBookmarkY);
            this.grpBookmarkProperties.Controls.Add(this.label13);
            this.grpBookmarkProperties.Controls.Add(this.label12);
            this.grpBookmarkProperties.Controls.Add(this.txtBookmarkName);
            this.grpBookmarkProperties.Controls.Add(this.label11);
            this.grpBookmarkProperties.Location = new System.Drawing.Point(6, 398);
            this.grpBookmarkProperties.Name = "grpBookmarkProperties";
            this.grpBookmarkProperties.Size = new System.Drawing.Size(428, 111);
            this.grpBookmarkProperties.TabIndex = 36;
            this.grpBookmarkProperties.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Bookmark Coordinates:";
            // 
            // btnAddToBookmarks
            // 
            this.btnAddToBookmarks.Location = new System.Drawing.Point(165, 82);
            this.btnAddToBookmarks.Name = "btnAddToBookmarks";
            this.btnAddToBookmarks.Size = new System.Drawing.Size(98, 23);
            this.btnAddToBookmarks.TabIndex = 33;
            this.btnAddToBookmarks.Text = "Add";
            this.btnAddToBookmarks.UseVisualStyleBackColor = true;
            this.btnAddToBookmarks.Click += new System.EventHandler(this.BtnAddToBookmarks_Click);
            // 
            // txtBookmarkX
            // 
            this.txtBookmarkX.Location = new System.Drawing.Point(150, 24);
            this.txtBookmarkX.Name = "txtBookmarkX";
            this.txtBookmarkX.Size = new System.Drawing.Size(100, 20);
            this.txtBookmarkX.TabIndex = 26;
            this.txtBookmarkX.TextChanged += new System.EventHandler(this.TxtBookmarkX_TextChanged);
            // 
            // txtBookmarkY
            // 
            this.txtBookmarkY.Location = new System.Drawing.Point(277, 24);
            this.txtBookmarkY.Name = "txtBookmarkY";
            this.txtBookmarkY.Size = new System.Drawing.Size(100, 20);
            this.txtBookmarkY.TabIndex = 27;
            this.txtBookmarkY.TextChanged += new System.EventHandler(this.TxtBookmarkY_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Bookmark Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(130, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "X";
            // 
            // txtBookmarkName
            // 
            this.txtBookmarkName.Location = new System.Drawing.Point(98, 56);
            this.txtBookmarkName.Name = "txtBookmarkName";
            this.txtBookmarkName.Size = new System.Drawing.Size(220, 20);
            this.txtBookmarkName.TabIndex = 31;
            this.txtBookmarkName.TextChanged += new System.EventHandler(this.TxtBookmarkName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(257, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Y";
            // 
            // btnRemoveFromBookmarks
            // 
            this.btnRemoveFromBookmarks.Location = new System.Drawing.Point(129, 359);
            this.btnRemoveFromBookmarks.Name = "btnRemoveFromBookmarks";
            this.btnRemoveFromBookmarks.Size = new System.Drawing.Size(176, 23);
            this.btnRemoveFromBookmarks.TabIndex = 34;
            this.btnRemoveFromBookmarks.Text = "Remove";
            this.btnRemoveFromBookmarks.UseVisualStyleBackColor = true;
            this.btnRemoveFromBookmarks.Click += new System.EventHandler(this.BtnRemoveFromBookmarks_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Bookmarks";
            // 
            // lstBookmarks
            // 
            this.lstBookmarks.Location = new System.Drawing.Point(6, 34);
            this.lstBookmarks.MultiSelect = false;
            this.lstBookmarks.Name = "lstBookmarks";
            this.lstBookmarks.Size = new System.Drawing.Size(428, 314);
            this.lstBookmarks.TabIndex = 0;
            this.lstBookmarks.UseCompatibleStateImageBehavior = false;
            this.lstBookmarks.View = System.Windows.Forms.View.List;
            this.lstBookmarks.SelectedIndexChanged += new System.EventHandler(this.LstBookmarks_SelectedIndexChanged);
            this.lstBookmarks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LstBookmarks_MouseUp);
            // 
            // BtnChooseOholPath
            // 
            this.BtnChooseOholPath.Location = new System.Drawing.Point(24, 12);
            this.BtnChooseOholPath.Name = "BtnChooseOholPath";
            this.BtnChooseOholPath.Size = new System.Drawing.Size(172, 23);
            this.BtnChooseOholPath.TabIndex = 15;
            this.BtnChooseOholPath.Text = "Choose OHOL Path";
            this.BtnChooseOholPath.UseVisualStyleBackColor = true;
            this.BtnChooseOholPath.Click += new System.EventHandler(this.BtnChooseOholPath_Click);
            // 
            // TextOholPath
            // 
            this.TextOholPath.Location = new System.Drawing.Point(202, 14);
            this.TextOholPath.Name = "TextOholPath";
            this.TextOholPath.ReadOnly = true;
            this.TextOholPath.Size = new System.Drawing.Size(583, 20);
            this.TextOholPath.TabIndex = 16;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 582);
            this.Controls.Add(this.TextOholPath);
            this.Controls.Add(this.BtnChooseOholPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "OHOL Compass";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBookmarkProperties.ResumeLayout(false);
            this.grpBookmarkProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentY;
        private System.Windows.Forms.TextBox txtCurrentX;
        private System.Windows.Forms.Label label4;
        private Compass compass1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTargetY;
        private System.Windows.Forms.TextBox txtTargetX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstBookmarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBookmarkY;
        private System.Windows.Forms.TextBox txtBookmarkX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBookmarkName;
        private System.Windows.Forms.Button btnRemoveFromBookmarks;
        private System.Windows.Forms.Button btnAddToBookmarks;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox grpBookmarkProperties;
        private System.Windows.Forms.TextBox txtTargetName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCreateBookmark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCustomBookmarkName;
        private System.Windows.Forms.Button BtnChooseOholPath;
        private System.Windows.Forms.TextBox TextOholPath;
    }
}

