using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using ZAPBeachCampingLib.Core;

namespace ZAPBeachCampingLib.Invoice
{
    internal class InvoiceCreator
    {
        private Application applicationWord;
        private Document document;
        private int rowNumber = 1;
        public InvoiceCreator()
        {
        }

        /// <summary>
        /// Used to create invoice as a PDF file based on reservation
        /// </summary>
        /// <returns>path of pdf file</returns>
        public string Create(Reservation reservation, string templatePath, string templateFilename)
        {
            // Overide template document
            if (File.Exists(templatePath + "Temp.docx"))
            {
                File.Delete(templatePath + "Temp.docx");
            }
            File.Copy(templatePath + templateFilename, templatePath + "Temp.docx");

            // Delete invoice pdf
            if (File.Exists(templatePath + "Faktura.pdf"))
            {
                File.Delete(templatePath + "Faktura.pdf");
            }

            // Opens invoice template in word
            OpenWord();
            document = applicationWord.Documents.Open(templatePath + "Temp.docx");

            // Replaces bookmarks in invoice with reservation data 
            ReplaceBookmarks(reservation);

            // Convents .docx to .pdf
            document.Save();
            document.ExportAsFixedFormat(templatePath + "Faktura.pdf", WdExportFormat.wdExportFormatPDF, false);
            
            // Close word down
            document.Close();
            CloseWord();

            return templatePath + "Faktura.pdf";
        }

        /// <summary>
        /// Used to replace bookmarks in invoice with reservation data
        /// </summary>
        private void ReplaceBookmarks(Reservation reservation)
        {
            Customer customer = reservation.Customer;

            // **** Customer information
            SetText("ID_NAME", customer.FirstName + " " + customer.LastName);
            SetText("ID_ADDRESS", customer.Address);
            SetText("ID_CITY", customer.City);
            SetText("ID_PHONENUMBER", customer.PhoneNumber);
            SetText("ID_EMAIL", customer.Email);

            // **** Order number and date
            SetText("ID_ORDRENUMMER", reservation.OrderNumber.ToString("D8"));
            SetText("ID_ARRIVAL", reservation.StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            SetText("ID_DEPARTURE", reservation.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

            // **** Order Information
            PushInvoiceRows(reservation);
            SetText("ID_TOTAL", $"{reservation.GetTotalPrice()} DKK");

            // Set spaces for all the rest rows
            ReplaceRowsWithSpaces();
        }

        /// <summary>
        /// Used to push row text to the invoice
        /// </summary>
        void PushInvoiceRows(IInvoiceRows invoiceRows)
        {
            foreach (InvoiceRow invoiceRow in invoiceRows.ToInvoiceRows())
            {
                SetText($"ID_DESC{rowNumber}", invoiceRow.Description);
                SetText($"ID_AM{rowNumber}", invoiceRow.Other);
                SetText($"ID_PRICE{rowNumber}", invoiceRow.Price);
                rowNumber++;
            }
        }

        /// <summary>
        /// Used to replace rows with spaces
        /// </summary>
        void ReplaceRowsWithSpaces()
        {
            for (int i = 1; i <= 17; i++)
            {
                SetText($"ID_DESC{i}", " ");
                SetText($"ID_AM{i}", " ");
                SetText($"ID_PRICE{i}", " ");
            }
        }

        /// <summary>
        /// Used to opens office word
        /// </summary>
        private void OpenWord()
        {
            applicationWord = new Application();
            applicationWord.Visible = false;
        }

        /// <summary>
        /// Used to close office word
        /// </summary>
        private void CloseWord()
        {
            applicationWord.Quit(false);
        }

        /// <summary>
        /// Used to replace bookmark with text
        /// Can only be called once per bookmark
        /// </summary>
        private void SetText(string bookmark, string text)
        {
            // Finds a bookmark in a word document and replaces it with text
            if (document.Bookmarks.Exists(bookmark))
            {
                object oBookMark = bookmark;
                document.Bookmarks.get_Item(ref oBookMark).Range.Text = text;
            }
        }
    }
}