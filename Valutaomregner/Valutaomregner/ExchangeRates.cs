using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Windows;
using System.Windows.Documents;
using System.Runtime.InteropServices;

namespace Valutaomregner
{
    [XmlRoot(ElementName = "exchangerates")]
    //Valuta class that holds our ID and our List
    public class Valutakurser
    {
        [XmlAttribute]
        public DateTime id { get; set; }
        [XmlElement("dailyrates")]
        public DailyRates daily { get; set; }
    }

    //Class that populates our list
    public class DailyRates
    {
        [XmlElement("currency")]
        public List<Currency> Currency { get; set; }
    }

    //Class that holds the values of the list
    public class Currency
    {
        [XmlAttribute]
        public string code { get; set; }

        //[XmlAttribute]
        //public string desc { get; set; }
        [XmlAttribute]
        public double rate { get; set; }

        public Currency() { }
    }
}
