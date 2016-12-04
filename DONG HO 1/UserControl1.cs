using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace moi
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            timer1.Start();

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, 100, 100);
            this.Region = new Region(gp);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            string tg = string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Millisecond);
            e.Graphics.DrawString(tg, this.Font, Brushes.Blue, 0, 0);
        
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
