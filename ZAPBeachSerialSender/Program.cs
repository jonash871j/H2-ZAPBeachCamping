using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZAPBeachCampingLib;

namespace ZAPBeachSerialSender
{
    public class BufferWriter
    {
        private SerialPort serialPort;

        public BufferWriter(SerialPort serialPort)
        {
            this.serialPort = serialPort;

        }

        public void SendBuffer(byte[] buffer)
        {
            if (buffer.Length > 1000)
            {
                throw new Exception("To large");
            }
            serialPort.RtsEnable = true;
            serialPort.Open();
            serialPort.Write(buffer, 0, buffer.Length);
            serialPort.Close();
        }
    }

    class Program
    {
        static Manager manager = new Manager();

        static void Main(string[] args)
        {
            string[] spotsNumber = { "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11" };

            BufferWriter writer = new BufferWriter(new SerialPort("COM3", 11200));

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
