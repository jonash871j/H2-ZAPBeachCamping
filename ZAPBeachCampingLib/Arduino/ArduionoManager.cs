using System;
using System.Configuration;
using System.IO.Ports;
using System.Threading;

namespace ZAPBeachCampingLib.Arduino
{
    public class ArduionoManager
    {
        private DataAccess dal;
        public MessageEventHandler Log;

        public ArduionoManager()
        {
            dal = new DataAccess();
        }

        /// <summary>
        /// Used to start a thread that constantly sends 
        /// neweset spot statues to an arduiono every 5 second
        /// </summary>
        public void StartArduionoThread(string[] spotNumbers)
        {
            new Thread(() =>
            {
                // Create connection to arduiono on 11200 baud rate
                SerialPort serialPort = new SerialPort(ConfigurationManager.AppSettings["COMPort"], 11200);
                SerialBufferSender serialBufferSender = new SerialBufferSender(serialPort);

                // Sends newest spot statues every 5 second
                while (true)
                {
                    try
                    {
                        // Create empty buffer
                        byte[] buffer = new byte[spotNumbers.Length];
                        
                        // Puts spot statuses into buffer
                        for (int i = 0; i < spotNumbers.Length; i++)
                        {
                            buffer[i] = (byte)dal.GetSpotStatus(spotNumbers[i]);
                        }

                        // Sends buffer to arduiono
                        serialBufferSender.SendBuffer(buffer);
                    }
                    catch (Exception exception)
                    {
                        Log?.Invoke($"<{DateTime.Now} : ArduionoThread> {exception.Message}");
                    }
                    Thread.Sleep(5000);
                }
            }).Start();
        }
    }
}
