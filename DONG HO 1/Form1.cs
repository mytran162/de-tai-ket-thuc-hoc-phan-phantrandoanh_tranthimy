﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace moi
{
   
            public partial class Form1 : Form
    {
        Timer t = new Timer();

        int WIDTH = 300, HEIGHT = 300, secHAND = 140, minHAND = 110, hrHAND = 80;

        //center
        int cx, cy;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }
        string music;

        private void Form1_Load(object sender, EventArgs e)
        {
            //create bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            //center
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            //backcolor
            this.BackColor = Color.White;

            //timer
            t.Interval = 1000;   //in millisecond
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //create graphics
            g = Graphics.FromImage(bmp);

            //get time
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCoord = new int[2];
             
            //clear
            g.Clear(Color.White);

            //draw circle
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            //draw figure
            g.DrawString("12", new Font("Arial",12), Brushes.Black, new PointF(140, 2));
            g.DrawString("3", new Font("Arial",12), Brushes.Black, new PointF(286, 140));
            g.DrawString("6", new Font("Arial",12), Brushes.Black, new PointF(142, 282));
            g.DrawString("9", new Font("Arial",12), Brushes.Black, new PointF(0, 140));

            //second hand
            handCoord = msCoord(ss, secHAND);
            g.DrawLine(new Pen(Color.Red, 1f), new Point(cx,cy), new Point(handCoord[0], handCoord[1]));

            //minute hand
            handCoord = msCoord(mm, minHAND);
            g.DrawLine(new Pen(Color.Black, 2f), new Point(cx,cy), new Point(handCoord[0], handCoord[1]));

            //hour hand
            handCoord = hrCoord(hh%12, mm, hrHAND);
            g.DrawLine(new Pen(Color.Gray, 3f), new Point(cx,cy), new Point(handCoord[0], handCoord[1]));

            //load bmp in pictureBox1
            pictureBox1.Image = bmp;

            //disp time
            this.Text = "Analog Clock - " + hh + ":" + mm + ":" + ss;

            //dispose
            g.Dispose();
        }

        //coord for minute and second hand
        private int[] msCoord(int val, int hlen)
        {
            int[] Coord = new int[2];
            val *= 6;  //each minute and second make 6 degree

            if (val >= 0 && val <= 180)
            {
                Coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                Coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                Coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                Coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return Coord;
        }

        //coord for hour hand
         private int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];

             //each hour makes 30 degree
             //each min makes 0.5 degree
            int val = (int)((hval * 30)+(mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void T_set_Click(object sender, EventArgs e)
        {

        }

        private void mtb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void T_now_Click(object sender, EventArgs e)
        {

        }

        private void b2_Click(object sender, EventArgs e)
         {
             T_set.Text = mtb.Text;
             mtb.Text = "";
             time_set.Start();
         }

         private void b3_Click(object sender, EventArgs e)
         {
             Media.Ctlcontrols.stop();
             time_set.Stop();
         }

         private void b1_Click(object sender, EventArgs e)
         {
             OpenFileDialog open = new OpenFileDialog();
             if (open.ShowDialog() == DialogResult.OK)
             {
                 music = open.FileName;
                 textBox1.Text = open.SafeFileName;
             }
         }

         private void time_now_Tick(object sender, EventArgs e)
         {
             T_now.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
         }

         private void time_set_Tick(object sender, EventArgs e)
         {
             if (T_now.Text == T_set.Text)
             
                 Media.URL = music;
             }
         }


        }
    

        
    

