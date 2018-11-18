using System;

namespace FixedWidthParserWriter.Tests
{
    public class Invoice : FixedWidthDataFile<Invoice>
    {
        [FixedWidthFileField(Line = 1)]
        public string CompanyName { get; set; }

        // Format set on class with custom DefaultFormat so not required on each Attribute of DateTime Property
        [FixedWidthFileField(Line = 4, Start = 15, Length = 19/*, Format = "yyyy-MM-dd"*/)]
        public DateTime Date { get; set; }

        [FixedWidthFileField(Line = 4, Start = 43)]
        public string BuyerName { get; set; }

        [FixedWidthFileField(Line = 6, Start = 37)]
        public string InvoiceNumber { get; set; }

        [FixedWidthFileField(Line = -4, Length = 66, Pad = ' ', Format = "0,000.00")]
        public decimal AmountTotal { get; set; }

        [FixedWidthFileField(Line = -2, Start = 7, Length = 10/*, Format = "yyyy-MM-dd"*/)]
        public DateTime DateCreated { get; set; }

        [FixedWidthFileField(Line = -2, Start = 17, Length = 50, PadSide = PadSide.Left)]
        public string SignatoryTitle { get; set; }

        [FixedWidthFileField(Line = -1, Length = 66, PadSide = PadSide.Left)] // Line Negative - counted from bottom
        public string SignatureName { get; set; }

        public override void SetDefaultConfig()
        {
            //DefaultConfig.FormatNumberDecimal = "0,000.00";
            DefaultConfig.FormatDateTime = "yyyy-MM-dd";
        }
    }
}
