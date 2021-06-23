using System.IO.Ports;

namespace ZAPBeachCampingLib.Arduino
{
    internal class SerialBufferSender
    {
        private SerialPort serialPort;

        public SerialBufferSender(SerialPort serialPort)
        {
            this.serialPort = serialPort;
        }

        /// <summary>
        /// Sends buffer via serial port
        /// </summary>
        /// <param name="buffer"></param>
        public void SendBuffer(byte[] buffer)
        {
            serialPort.RtsEnable = true;
            serialPort.Open();
            serialPort.Write(buffer, 0, buffer.Length);
            serialPort.Close();
        }
    }
}