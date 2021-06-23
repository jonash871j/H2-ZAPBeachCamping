using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPBeachCampingLib.Arduino;
using ZAPBeachCampingLib.Invoice;

namespace ZAPBeachCampingServices
{
    class Program
    {
        static void Main(string[] args)
        {
            InvoiceManager invoiceManager = new InvoiceManager();
            invoiceManager.Log += OnLog;
            invoiceManager.StartInvoiceThread();

            ArduionoManager arduionoManager = new ArduionoManager();
            arduionoManager.Log += OnLog;
            arduionoManager.StartArduionoThread(new string[]{ "H2", "H3", "H4", "H5", "H7", "H8", "H10", "H11" });
        }

        private static void OnLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
