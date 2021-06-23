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

        public InvoiceCreator()
        {
        }

        /// <summary>
        /// Used to create invoice as a PDF file based on reservation
        /// </summary>
        /// <returns>path of pdf file</returns>
        public string Create(Reservation reservation, string templatePath, string templateFilename)
        {
            OpenWord();

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
            document = applicationWord.Documents.Open(templatePath + "Temp.docx");

            // Creates a invoice document for customer
            CreateInvoice(reservation);

            // Convents .docx to .pdf
            document.Save();
            document.ExportAsFixedFormat(templatePath + "Faktura.pdf", WdExportFormat.wdExportFormatPDF, false);
            document.Close();

            CloseWord();

            return templatePath + "Faktura.pdf";
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
            Reservation r = reservation;
            Customer c = reservation.Customer;
            Spot s = reservation.Spot;
            PriceCalculator pC = new PriceCalculator(reservation);
            int line = 1;

            // **** Customer information
            ReplaceText("ID_NAME", c.FirstName + " " + c.LastName);
            ReplaceText("ID_ADDRESS", c.Address);
            ReplaceText("ID_CITY", c.City);
            ReplaceText("ID_PHONENUMBER", c.PhoneNumber);
            ReplaceText("ID_EMAIL", c.Email);

            // **** Order number and date
            ReplaceText("ID_ORDRENUMMER", r.OrderNumber.ToString("D8"));
            ReplaceText("ID_ARRIVAL", r.StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            ReplaceText("ID_DEPARTURE", r.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

            // **** Order Information

            // Spot

            if (reservation.SeasonType == SeasonType.None)
            {
                PushLine(reservation.GetSpotDescription(), $"{r.GetTravelPeriodInDays()} døgn", $"{pC.GetTotalSpotPrice()} DKK");

                if (r.Spot.SpotType == SpotType.CampingSite)
                {
                    PushLine("Gratis pladsgebyr for hver 3 dag", Math.Floor(r.GetTravelPeriodInDays() / 3.0) + " døgns rabat", $"{pC.GetCampingSpotDiscountPrice()} DKK");
                }

                // Default spot addition
                PushLine("Ekstra god udsigt (75 DKK pr. døgn)", s.IsGoodView ? "Ja" : "Nej", $"{pC.GetGoodViewPrice()} DKK");
                if (s.SpotType == SpotType.HutSite)
                {
                    PushLine("Slutrengøring (150 DKK)", reservation.IsPayForCleaning ? "Ja" : "Nej", $"{pC.GetHutSpotCleaningPrice()} DKK");
                }

                // Customer types
                PushLine(
                    $"Voksne ({s.Prices["ADULT_PRICE"].GetPrice()} DKK pr. voksen)",
                    $"Antal {r.CustomerTypes.FindAll(ct => ct == CustomerType.Adult).Count}",
                    $"{pC.GetTotalAdultPrice()} DKK"
                );
                PushLine(
                     $"Børn ({s.Prices["CHILD_PRICE"].GetPrice()} DKK pr. barn)",
                     $"Antal {r.CustomerTypes.FindAll(ct => ct == CustomerType.Child).Count}",
                     $"{pC.GetTotalChildPrice()} DKK"
                 );
                PushLine(
                     $"Hunde ({s.Prices["DOG_PRICE"].GetPrice()} DKK pr. hund)",
                     $"Antal {r.CustomerTypes.FindAll(ct => ct == CustomerType.Dog).Count}",
                     $"{pC.GetTotalDogPrice()} DKK"
                 );
            }
            else
            {
                PushLine(reservation.GetSpotDescription(), $" ", $"{pC.GetTotalSpotPrice()} DKK");
            }
            
            foreach (Addition addition in r.Additions.GroupBy(a => a.Name).Select(y => y.FirstOrDefault()))
            {
                int additionAmount = r.Additions.FindAll(a => a.Name == addition.Name).Count;
                double price = addition.Price * additionAmount;

                if (addition.IsDailyPayment)
                {
                    price *= r.GetTravelPeriodInDays();
                }

                PushLine(
                    $"{addition.Name} ({addition.Price} DKK{(addition.IsDailyPayment ? "pr. døgn" : "")})",
                    $"Antal {additionAmount}",
                    $"{price} DKK"
                );
            }

            // Total
            ReplaceText("ID_TOTAL", $"{pC.GetTotalPrice()} DKK");

            // Set spaces for all the rest fields
            for (int i = 1; i <= 17; i++)
            {
                ReplaceText($"ID_DESC{i}", " ");
                ReplaceText($"ID_AM{i}", " ");
                ReplaceText($"ID_PRICE{i}", " ");
            }

            void PushLine(string description, string other, string price)
            {

                ReplaceText($"ID_DESC{line}", description);
                ReplaceText($"ID_AM{line}", other);
                ReplaceText($"ID_PRICE{line}", price);
                line++;
            }
        }
    }
}
