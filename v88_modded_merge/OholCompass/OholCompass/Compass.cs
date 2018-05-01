using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OholCompass
{
    public partial class Compass : UserControl
    {
        #region Member Fields

        private int angle = 0;
        private Point center;
        private Bitmap offscreenBitmap;

        #endregion

        #region Properties

        public Destination TargetDestination { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        #endregion

        #region Constructor

        public Compass()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        static double DegreeBearing(double lat1, double lon1, double lat2, double lon2)
        {
            var dLon = ToRad(lon2 - lon1);
            var dPhi = Math.Log(
                Math.Tan(ToRad(lat2) / 2 + Math.PI / 4) / Math.Tan(ToRad(lat1) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        public static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToBearing(double radians)
        {
            return (ToDegrees(radians) + 360) % 360;
        }

        public void UpdateHeading(int newAngle)
        {
            angle = newAngle % 360;
        }

        #endregion

        #region Event Handlers

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (center == Point.Empty) center = new Point(Left + Width / 2, Top + Height / 2);
            if (offscreenBitmap != null)
            {
                offscreenBitmap.Dispose();
                offscreenBitmap = null;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (offscreenBitmap == null)
            {
                offscreenBitmap = new Bitmap(Properties.Resources.compassbg2);
            }

            base.OnPaint(pe);

            if (!DesignMode)
            {
                double bearing = 0;

                if (TargetDestination != null)
                {
                    Point target = new Point(TargetDestination.X, TargetDestination.Y); // target
                    Point center = new Point(CurrentX, CurrentY); // our location, origin

                    bearing = DegreeBearing(center.Y / 10000.0, center.X / 10000.0, target.Y / 10000.0, target.X / 10000.0);
                }

                using (Graphics gfx = Graphics.FromImage(offscreenBitmap))
                {
                    gfx.DrawImage(Properties.Resources.compassbg2, 0, 0, offscreenBitmap.Width, offscreenBitmap.Height);
                    gfx.TranslateTransform(((float)offscreenBitmap.Width / 2), (float)offscreenBitmap.Height / 2);
                    gfx.RotateTransform((int)bearing);
                    gfx.TranslateTransform(-(float)offscreenBitmap.Width / 2, -(float)offscreenBitmap.Height / 2);
                    gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gfx.DrawImage(Properties.Resources.compassneedle2, 1, 1, offscreenBitmap.Width, offscreenBitmap.Height);
                }

                pe.Graphics.DrawImage(offscreenBitmap, 0, 0, Size.Width, Size.Height);
            }
        }

        #endregion
    }
}




