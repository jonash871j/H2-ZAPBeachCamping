using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ZAPBeachCampingLib
{
    internal class InvoiceCreator
    {
        private Application applicationWord;
        private Document document;
        private EmailSender email;

        public InvoiceCreator(EmailSender email)
        {
            this.email = email;
        }

        /// <summary>
        /// Sends invoice to customer from reservation 
        /// </summary>
        public void Send(Reservation reservation, string templatePath, string templateFilename)
        {
            // Overide template document
            if (File.Exists(templatePath + "Temp.docx"))
                File.Delete(templatePath + "Temp.docx");
            File.Copy(templatePath + templateFilename, templatePath + "Temp.docx");

            // Delete invoice pdf
            if (File.Exists(templatePath + "Faktura.pdf"))
                File.Delete(templatePath + "Faktura.pdf");

            // Opens invoice template in word
            document = applicationWord.Documents.Open(templatePath + "Temp.docx");

            // Creates a invoice document for customer
            CreateInvoice(reservation);

            // Convents .docx to .pdf
            document.Save();
            document.ExportAsFixedFormat(templatePath + "Faktura.pdf", WdExportFormat.wdExportFormatPDF, false);
            document.Close();

            // Sends email to customer
            email.SendEmailAttachement(
                reservation.Customer.Email,
                "ZAP Beach Camping faktura",
                "Hej " + reservation.Customer.FirstName + "\n\nTusind tak for din bestilling, vi håber du får en uforglemmelig tur hos ZAP Beach Camping.\n\n\nMed venlig hilsen\n\nZAP Beach Camping",
                templatePath + "Faktura.pdf");
        }

        /// <summary>
        /// Used to opens office word
        /// </summary>
        public void OpenWord()
        {
            applicationWord = new Application();
            applicationWord.Visible = false;
        }

        /// <summary>
        /// Used to close office word
        /// </summary>
        public void CloseWord()
        {
            applicationWord.Quit(false);
        }

        /// <summary>
        /// Used to replace bookmark with text
        /// </summary>
        private void ReplaceText(string bookmark, string text)
        {
            // Finds a bookmark in a word document and replaces it with text
            if (document.Bookmarks.Exists(bookmark))
            {
                object oBookMark = bookmark;
                document.Bookmarks.get_Item(ref oBookMark).Range.Text = text;
            }
        }

        /// <summary>
        /// Used to create a invoice document based on reservation
        /// </summary>
        private void CreateInvoice(Reservation reservation)
        {
            Customer c = reservation.Customer;
            PriceCalculator priceCalculator = new PriceCalculator(reservation);

            //Customer information
            ReplaceText("ID_ADDRESS", c.Address);
            ReplaceText("ID_CITY", c.City);
            ReplaceText("ID_PHONENUMBER", c.PhoneNumber);
            ReplaceText("ID_EMAIL", c.Email);

            //Order number and date
            ReplaceText("ID_ORDRENUMMER", reservation.OrderNumber.ToString());
            ReplaceText("ID_ARRIVAL", reservation.StartDate.ToShortDateString());
            ReplaceText("ID_DEPARTURE", reservation.EndDate.ToShortDateString());

            //Order Information

            for (int i = 1; i <= 17; i++)
            {
                ReplaceText($"ID_DESC{i}", "Hello");
                ReplaceText($"ID_AM{i}", "123");
                ReplaceText($"ID_PRICE{i}", "Hello");
            }
            ReplaceText("ID_TOTAL", $"{priceCalculator.GetTotalPrice()} DKK");
        }
    }
}
