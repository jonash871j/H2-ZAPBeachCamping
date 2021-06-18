using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Invoice
{
    class InvoiceCreator
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
        public void Send(string templatePath, string templateFilename)
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
            CreateInvoice();

            // Convents .docx to .pdf
            document.Save();
            document.ExportAsFixedFormat(templatePath + "Faktura.pdf", WdExportFormat.wdExportFormatPDF, false);
            document.Close();

            // Sends email to customer
            //email.sendemailattachement(
            //    "rasmus@vinperlen.dk",
            //    "zap beach camping faktura",
            //    "hej " + "rasmus" + "\n\ntusind tak for din bestilling, vi håber du får en uforglemmelig tur hos zap beach camping.\n\n\nmed venlig hilsen\n\nzap beach camping",
            //    templatepath + "faktura.pdf");
        }

        /// <summary>
        /// Used to opens office word
        /// </summary>
        public void OpenWord()
        {
            applicationWord = new Application();
            applicationWord.Visible = true;
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
        private void CreateInvoice()
        {


            //Customer information
            ReplaceText("ID_ADDRESS", "Humlebivej 1");
            ReplaceText("ID_CITY", "Holbæk, 4500");
            ReplaceText("ID_PHONENUMBER", "12 23 45 56");
            ReplaceText("ID_EMAIL", "12 23 45 56");

            //Order number and date
            ReplaceText("ID_ORDRENUMMER", "123456789");
            ReplaceText("ID_ARRIVAL", "2021-06-18");
            ReplaceText("ID_DEPARTURE", "2021-06-21");

            //Order Information

            for (int i = 1; i <= 17; i++)
            {
                ReplaceText($"ID_DESC{i}", "Hello");
                ReplaceText($"ID_AM{i}", "123");
                ReplaceText($"ID_PRICE{i}", "Hello");
            }
            ReplaceText("ID_TOTAL", "Hello");
        }
    }
}
