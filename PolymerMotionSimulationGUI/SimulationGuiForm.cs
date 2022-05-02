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
        public static PolymerChain polymerChain;
        private Thread t;
        private readonly BlockingCollection<PolymerChain> SimulationResults = 
            new BlockingCollection<PolymerChain>(1000); // limit to 1000 - producer will wait until consumed
        private PointPairList ppList = new PointPairList();
        

        public SimulationGuiForm()
        {
            InitializeComponent();

            DrawBlackCanvas();

            zedGraphControl1.GraphPane.AddCurve("", ppList, Color.Red, SymbolType.None);

            polymerChain = new PolymerChain();
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
            //for (int i = 0; i < pol; i++)
            //{
            //    string name = RandomStringGen.GetRandomString();
            //    polymerChain.Add(name);
            //}

            for (int i = 0; i < (Global.SimulationSteps / Global.WriteToFileSteps); i++)
            {
                Simulation.SimulateMotion(polymerChain, Global.WriteToFileSteps);
                // save the generated result,
                // obviously will save only the "written to file" iterations 
                SimulationResults.Add(polymerChain); 
            }
            
            SimulationResults.CompleteAdding(); // signal that simulation has finished
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
                    Point2d itemLoc = item.Location;
                    Point2d translatedLoc = itemLoc;//itemLoc.GetTranslated(Global.Width / 2, Global.Height / 2);

                    x = (int) Math.Round(translatedLoc.X, 0);
                    y = (int) Math.Round(translatedLoc.Y, 0);

                    g.FillEllipse(Brushes.Yellow, x, y, 3, 3);                    
                }
            }

            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // try getting next simulation from the saved (if there are any)
            PolymerChain currPolymerChain;
            if (!SimulationResults.IsCompleted && SimulationResults.TryTake(out currPolymerChain))
            {
                DrawPolymerChain(currPolymerChain); // pass the fetched simulation to draw it

                var totalPotential = currPolymerChain.GetTotalPotential(); // total potential
                textBox1.Text += totalPotential + "\r\n";
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();

                DrawZGraph(totalPotential); // pass the fetched simulation's potential to draw on graph
            }
        }

        int totalX = 0;
        void DrawZGraph(double totalPotential)
        {
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