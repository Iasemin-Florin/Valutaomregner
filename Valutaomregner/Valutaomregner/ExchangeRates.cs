using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Windows;
using System.Windows.Documents;

namespace Valutaomregner
{
    /*[XmlRoot(ElementName = "exchangerates")]
    public class ExchangeRates
    {
        public string Code { get; set; }

        public double Rate { get; set; }
    }*/

    [Serializable]
    
    [XmlRoot(Namespace = "http://www.w3.org/2001/XMLSchema-instance",
        ElementName = "exchangerates",
        DataType = "Valutakurser")]
    public class Valutakurser
    {
        public DateTime Id { get; set; }
        [XmlArray("dailyrates")]
        
        public Currency Currency { get; set; }
    }

    public class Currency
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("desc")]
        public string Desc { get; set; }
        [XmlAttribute("rate")]
        public double Rate { get; set; }

        public Currency() { }
    }


    public class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class DailyRates
    {
        public List<Valutakurser> exchangeRates = new List<Valutakurser>();
        
        public void DisplayList()
        {
            for (int i = 0;  i < exchangeRates.Count();  i++)
            {
                MessageBox.Show(i.ToString());
            }
        }
    }
}

/*, new XmlRootAttribute("exchangerates")*/