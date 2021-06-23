using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZAPBeachCampingLib;

namespace ZAPBeachSerialSender
{


    class Program
    {
        static Manager manager = new Manager();

        static void Main(string[] args)
        {
            string[] spotsNumber = { "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11" };

            SerialBufferSender writer = new SerialBufferSender(new SerialPort(ConfigurationManager.AppSettings["COMPort"], 11200));

            while(true)
            {
                List<byte> data = new List<byte>();

                foreach(string spotNumber in spotsNumber)
                {
                    data.Add((byte)manager.GetSpotStatus(spotNumber));
                }


                writer.SendBuffer(data.ToArray());
                Thread.Sleep(5000);
            }
           
        }
    }
}
