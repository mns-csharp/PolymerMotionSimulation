using PolymerMotionSimulation;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PolymerMotionSimulationGUI
{
    public partial class SimulationGuiForm : Form
    {
        private int x = 0;
        private int y = 0;
        public const int polymerLength = 30;
        public const double beadDistance = GlobalConstants.Radius;
        public static PolymerChain polymerChain;
        public const int totalIterations = 1000000;
        public const int writeToFileIterations = 100;
        private Thread t;
        
        public SimulationGuiForm()
        {
            InitializeComponent();

            polymerChain = new PolymerChain(polymerLength, beadDistance);
            t = new Thread(new ThreadStart(Run));
            t.Start();
        }
        protected void Abort_Click(object sender, EventArgs e)
        {
            paintBoxTimer.Stop();
        }
        protected void Suspend_Click(object sender, EventArgs e)
        {
            paintBoxTimer.Start();
        }

        public void Run()
        {            
            Random random = new Random();
            for (int i = 0; i < polymerLength; i++)
            {
                string name = RandomStringGen.GetRandomString();
                polymerChain.Add(name);
            }

            for (int i = 0; i < (totalIterations / writeToFileIterations); i++)
            {
                Simulation.SimulateMotion(polymerChain, writeToFileIterations);
                double totalPotential = polymerChain.GetTotalPotential();
            }
        }

        void Draw()
        {
            //if (pictureBox1.Image == null)
            //{
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                pictureBox1.Image = bmp;
            //}
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                foreach (Bead item in polymerChain)
                {
                    x = (int)Math.Round(item.Location.X, 0);
                    y = (int)Math.Round(item.Location.Y, 0);
                    g.FillEllipse(Brushes.Red, x, y, 10, 10);
                }
            }
            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();

            textBox1.Text = polymerChain.ToString();
        }

        private void SimulationGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
    }
}