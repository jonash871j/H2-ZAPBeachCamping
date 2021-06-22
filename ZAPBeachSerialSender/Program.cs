﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
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
            NoOrder,
            LeavingYoday,
            OrderReservated,
            CommingToday
        };

        static void Main(string[] args)
        {
            string[] spotsNames = { "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11", "H12" };

            SpotStatus[] spotStatuses =
            {
                SpotStatus.NoOrder,
                SpotStatus.CommingToday,
                SpotStatus.OrderReservated,
                SpotStatus.CommingToday,
                SpotStatus.LeavingYoday,
                SpotStatus.CommingToday,
                SpotStatus.NoOrder,
                SpotStatus.CommingToday,
            };
            BufferWriter writer = new BufferWriter(new SerialPort("COM5", 11200));
            List<byte> data = new List<byte>();

            for (int i = 0; i < spotStatuses.Length; i++)
            {
                data.Add((byte)spotStatuses[i]);
            }

            writer.SendBuffer(data.ToArray());
        }
    }
}
