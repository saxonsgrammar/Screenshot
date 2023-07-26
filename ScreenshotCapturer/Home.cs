using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace ScreenshotCapturer
{
    public partial class Home : Form
    {
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;
        public Home()
        {
            InitializeComponent();
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            saveScreenshot.FileName = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
            saveScreenshot.ShowDialog();
            timer1.Interval = 5000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(400);
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save(saveScreenshot.FileName, ImageFormat.Png);
        }
    }
}