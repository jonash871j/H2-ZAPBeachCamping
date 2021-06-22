using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPBeachCampingLib;

namespace ZAPBeachSerialSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] spotsNames = { "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11", "H12" };
            List<Spot> spots = new List<Spot>();
            Manager manager = new Manager();
                
            foreach (string spotName in spotsNames)
            {
                spots.Add(manager.GetSpot(spotName));

            }
        }
    }
}
