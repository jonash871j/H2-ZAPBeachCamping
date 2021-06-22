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

        static List<Reservation> GetReservationsToday(string spotNumber)
        {
            return manager.GetReservationsFromStartDateAndSpotNumber(DateTime.Now, spotNumber);
        }
        static List<Reservation> GetToday(string spotNumber)
        {
            return manager.GetReservationsFromStartDateAndSpotNumber(DateTime.Now, spotNumber);
        }
        static List<Reservation> GetCommingTheNextWeek(string spotNumber)
        {
            return manager.GetReservationsFromStartDateAndSpotNumber(DateTime.Now.AddDays(1), spotNumber);
        }
        enum SpotStatus
        {
            NoOrder = 1,
            LeavingYoday = 2,
            OrderReservated = 3,
            CommingToday = 4
        };

        static void Main(string[] args)
        {
            string[] spotsNames = { "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11", "H12" };

            BufferWriter writer = new BufferWriter(new SerialPort("COM3", 11200));

            while(true)
            {
                Console.WriteLine();
                SpotStatus[] spotStatuses = new SpotStatus[8];
                Random rng = new Random();

                for (int i = 0; i < 8; i++)
                {
                    spotStatuses[i] = (SpotStatus)rng.Next(1, 5);
                    Console.WriteLine(spotStatuses[i]);
                }
                List<byte> data = new List<byte>();

                for (int i = 0; i < spotStatuses.Length; i++)
                {
                    data.Add((byte)spotStatuses[i]);
                }

                writer.SendBuffer(data.ToArray());
                Thread.Sleep(5000);
            }
           
        }
    }
}
