using System;
using System.Collections.Generic;

namespace DatenbankUWPMVVM.Core.Models
{
    // Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and List Detail.
    public class Baugruppen
    {
        public string ID { get; set; }

        public string BOM_ID { get; set; }

        public string Bezeichnung { get; set; }

        public string Kommentar { get; set; }

        public double Letzte_EK_Kosten { get; set; }

        public string EKU { get; set; }

        public string VK_10 { get; set; }
        public string VK_15 { get; set; }
        public string VK_20 { get; set; }


        //public ICollection<SampleOrderDetail> Details { get; set; }

        //public override string ToString()
        //{
        //    return $"{Company} {Status}";
        //}

        //public string ShortDescription => $"Order ID: {OrderID}";
    }
}
