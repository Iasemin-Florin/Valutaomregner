using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Globalization;
using System.Xml;

using System.Xml.Serialization;

namespace Valutaomregner
{
    public class ApiHelper
    {
        
        //Creating the Deserialization method
        public void DeserializeObject(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(Valutakurser));
            Valutakurser valutakurser = (Valutakurser)serializer.Deserialize(reader);

            Console.Write(valutakurser.daily.Currency.Count());
        }
    }
}
 
