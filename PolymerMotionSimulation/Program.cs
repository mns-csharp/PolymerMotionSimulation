using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerSimulation__from__python
{
    class Program
    {
        public static void Main()
        {
            const int polymerLength = 30;
            const double beadDistance = 3.8;
            //create polymer chain
            PolymerChain polymerChain = new PolymerChain(polymerLength, beadDistance);
            Random random = new Random();
            for (int i = 0; i < polymerLength; i++)
            {
                string randomString = RandomStringGen.GetRandomString();
                polymerChain.AddBead(randomString);
            }

            SimulationContrioller.SimulateMotion(polymerChain);
        }
    }
}
