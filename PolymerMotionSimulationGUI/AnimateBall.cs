using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PolymerMotionSimulationGUI
{
    public partial class AnimateBall : Form
    {
        private int x = 0;
        private int y = 0;
        //private Button suspend = new Button();
        //private Button resume = new Button();
        //private Button abort = new Button();
        Thread t = null;

        public AnimateBall()
        {
            InitializeComponent();
                        
            BackColor = Color.White;
            abort.Text = "Abort";
            suspend.Text = "Suspend";
            resume.Text = "Resume";

            //int w = 20;
            

            t = new Thread(new ThreadStart(Run));
            t.Start();
        }
        protected void Abort_Click(object sender, EventArgs e)
        {
            t.Abort();
        }
        protected void Suspend_Click(object sender, EventArgs e)
        {
            t.Join();
        }
        protected void Resume_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillEllipse(Brushes.Red, x, y, 10, 10);
            base.OnPaint(e);
        }
        public void Run()
        {
            int dx = 2, dy = 2;
            x = 1;
            y = 1;

            while (true)
            {
                for (int i = 0; i < 60; i++)
                {
                    x += dx;
                    y += dy;
                    Invalidate();
                    Thread.Sleep(10);
                }

                dx = -dx;
                dy = -dy;
            }
        }
    }
}