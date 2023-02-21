using System;
using System.Collections.Generic;

namespace DatenbankUWPMVVM.Core.Models
{
    // Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and List Detail.
    public class Bauteil
    {
        public string ID { get; set; }

        public string Hersteller { get; set; }

        public string Lieferant_1 { get; set; }
        public string Lieferant_2 { get; set; }
        public string Lieferant_3 { get; set; }
        public string Lieferant_4 { get; set; }
        public string Lieferant_5 { get; set; }
        public string Lieferant_6 { get; set; }
        public string Lieferant_7 { get; set; }

        public string PositionsName { get; set; }

        public string KurzName { get; set; }

        public string LangName { get; set; }

        public string Kategorie { get; set; }

        public string HerstellerArtikelNr { get; set; }

        public string LieferantenArtikelNr { get; set; }

        //public ICollection<SampleOrder> Orders { get; set; }
    }
}
