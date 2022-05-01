using PolymerMotionSimulation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace PolymerMotionSimulationGUI
{
    public partial class SimulationGuiForm : Form
    {
        private int x = 0;
        private int y = 0;
        public const int polymerLength = 30;
        public const double beadDistance = Global.MaximumAtomicDistance;
        public static PolymerChain polymerChain;
        public const int totalIterations = 1000000;
        public const int writeToFileIterations = 100;
        private Thread t;
        private readonly BlockingCollection<PolymerChain> SimulationResults = 
            new BlockingCollection<PolymerChain>(1000); // limit to 1000 - producer will wait until consumed
        private PointPairList ppList = new PointPairList();
        

        public SimulationGuiForm()
        {
            InitializeComponent();

            DrawBlackCanvas();

            zedGraphControl1.GraphPane.AddCurve("", ppList, Color.Red, SymbolType.None);

            polymerChain = new PolymerChain(polymerLength, beadDistance);
            t = new Thread(new ThreadStart(RunSimulationThread));
            t.Start();
            textBox1.Text = "START" + "\r\n";
        }
        protected void Abort_Click(object sender, EventArgs e)
        {
            paintBoxTimer.Stop();
        }
        protected void Suspend_Click(object sender, EventArgs e)
        {
            paintBoxTimer.Start();
        }

        public void RunSimulationThread()
        {            
            Random random = Global.Random;
            for (int i = 0; i < polymerLength; i++)
            {
                string name = RandomStringGen.GetRandomString();
                polymerChain.Add(name);
            }

            for (int i = 0; i < (totalIterations / writeToFileIterations); i++)
            {
                Simulation.SimulateMotion(polymerChain, writeToFileIterations);
                SimulationResults.Add(polymerChain); // save the generated result, obviously will save only the written to file simulations 
            }
            
            SimulationResults.CompleteAdding();
        }

        void DrawBlackCanvas()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
            }
            pictureBox1.Image = bmp;
        }

        void DrawPolymerChain(PolymerChain currPolymerChain)
        {
            DrawBlackCanvas();

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                foreach (Bead item in currPolymerChain)
                {
                    Point2d translated = item.Location.GetTranslated(Global.Center);

                    x = (int)Math.Round(translated.X, 0);
                    y = (int)Math.Round(translated.Y, 0);

                    g.FillEllipse(Brushes.Yellow, x, y, 3, 3);                    
                }
            }

            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!SimulationResults.IsCompleted && SimulationResults.TryTake(out var currPolymerChain))
            {
                DrawPolymerChain(currPolymerChain);

                textBox1.Text += currPolymerChain.GetTotalPotential() + "\r\n";
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();

                DrawZGraph(currPolymerChain);    
            }
        
        }

        int totalX = 0;
        void DrawZGraph(PolymerChain currPolymerChain)
        {
            double totalPotential = currPolymerChain.GetTotalPotential();
            ppList.Add(totalX++, totalPotential);  

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void SimulationGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
    }
}