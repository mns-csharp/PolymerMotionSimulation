using PolymerMotionSimulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace PolymerMotionSimulationGUI
{
    public partial class ZGraphTestForm : Form
    {
        public ZGraphTestForm()
        {
            InitializeComponent();

            PolymerChain polymerChain = new PolymerChain(GlobalConstants.MaxLengthOfPolymer_N, GlobalConstants.Radius);

            for (int i = 0; i < GlobalConstants.MaxLengthOfPolymer_N; i++)
            {
                polymerChain.Add(RandomStringGen.GetRandomString());
                //Console.WriteLine("({0}, {1})", polymerChain[i].Location.X, polymerChain[i].Location.Y);
            }

            PointPairList ppList = new PointPairList();

            for (int i = 0; i < 30; i++)
            {
                Point2d location = polymerChain[i].Location;
                ppList.Add(location.X, location.Y);
            }

            zedGraphControl1.GraphPane.AddCurve("", ppList, Color.Black);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
