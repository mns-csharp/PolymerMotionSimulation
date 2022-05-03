using PolymerMotionSimulation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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
        private static Simulation simulation;
        private Thread t;
        private PointPairList pointPairList = new PointPairList();

        // limit to 1000 - producer will wait until consumed
        private readonly BlockingCollection<PolymerChain> blockingCollection 
            = new BlockingCollection<PolymerChain>(1000);
        
        public SimulationGuiForm()
        {
            InitializeComponent();

            polymerChain = new PolymerChain(Global.PolymerSize_N, Global.MaxAtomDist);
            polymerChain.InitializeBeads();

            simulation = new Simulation();
            simulation.PolymerChain = polymerChain;
            simulation.WritetoFileSteps = Global.WriteToFileSteps;

            t = new Thread(new ThreadStart(RunSimulationThread));
            t.Start();

            DrawBlackCanvas();
            zedGraphControl1.GraphPane.AddCurve("", pointPairList, Color.Red, SymbolType.None);             
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
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < (Global.SimulationSteps / Global.WriteToFileSteps); i++)
            {
                simulation.SimulateMotion();
                // save the generated result,
                // obviously will save only the "written to file" iterations 
                blockingCollection.Add(polymerChain);

                //print to a text file
                sb.AppendFormat("{0,3}\t{1,3}\t{2,20}\t{3,30}\t{4,30}\t{5}\t{6,20}\t{7}\n", i, simulation.Index, simulation.Bead, simulation.PrevPotential, simulation.AfterPotential, simulation.IsMoved, simulation.TotalPotential, polymerChain.ToString());
                Console.WriteLine(sb.ToString());
                TextWriter.Write("polymer_data.txt", sb.ToString());
                sb.Clear();
            }
            
            blockingCollection.CompleteAdding(); // signal that simulation has finished
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
            if (!blockingCollection.IsCompleted && blockingCollection.TryTake(out currPolymerChain))
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
            pointPairList.Add(totalX++, totalPotential);  

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void SimulationGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
    }
}