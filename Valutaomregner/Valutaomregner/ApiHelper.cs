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
using System.Xml.XPath;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace Valutaomregner
{
    [XmlRoot(ElementName = "DailyCurrency")]
    public class ApiHelper
    {
        
        public void DeserializeObject(string filename)
        {
            /*Console.WriteLine("Reading with Stream");
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
            new XmlSerializer(typeof(ExchangeRates));

            // Declare an object variable of the type to be deserialized.
            ExchangeRates i;

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                  i = (ExchangeRates)serializer.Deserialize(reader);
            }

            // Write out the properties of the object.
            Console.Write(
            i.code + "\t" +
            i.rate);*/

            /*XmlSerializer reader = new XmlSerializer(typeof(ExchangeRates));
            StreamReader file = new StreamReader(filename);
            ExchangeRates read = (ExchangeRates)reader.Deserialize(file);
            Console.Write(read.code, read.rate);*/
        }

        public void SerializeElement(string filename)
        {
            Test b = new Test {Name = "Gordon Ramsey", Age = 10 };
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            StreamWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, b);
            writer.Close();

            XmlSerializer reader = new XmlSerializer(typeof(Test));
            StreamReader file = new StreamReader(filename);
            Test read = (Test)reader.Deserialize(file);
            file.Close();

            Console.Write(read.Name, read.Age);
        }
        public static T DeserializeElement<T>(string filename)
        {
            try
            {
                //XmlRootAttribute xRoot = new XmlRootAttribute();
                //xRoot.ElementName = "exchangerates ";
                //xRoot.Namespace = "http://www.w3.org/2001/XMLSchema-instance";
                
                T result;
                XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("exchangerates"));
                
                using (TextReader tr = new StringReader(filename))
                {
                    result = (T)serializer.Deserialize(tr);
                }

                return result;
            }
            catch { throw; }
        }


        public void SerializeNode(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlNode));
            XmlNode xmlNode = new XmlDocument().CreateNode(XmlNodeType.Element,"MyNode", "ns");
            xmlNode.InnerText = "hello node";
            TextWriter writer = new StreamWriter(filename);
            xmlSerializer.Serialize(writer, xmlNode);
            writer.Close();
        }




        












        /*public void SerializeObject()
        {
            ExchangeRates rates = new ExchangeRates();
            rates.code = "AUG";
            rates.rate = 7.44;

            XmlSerializer srz = new XmlSerializer(typeof(ExchangeRates));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//test.xml";

            FileStream fs = File.Create(path);

            srz.Serialize(fs, rates);
            fs.Close();
        }*/
    }

    /*public void DeserializeObject()
    {
        Console.WriteLine("Reading with Stream");
        // Create an instance of the XmlSerializer.
        XmlSerializer serializer =
        new XmlSerializer(typeof(DailyRates));

        // Declare an object variable of the type to be deserialized.
        ExchangeRates i;
        string URL = "https://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";
        WebClient client = new WebClient();
        Stream stream = client.OpenRead(URL);
        DailyRates DR = (DailyRates)serializer.Deserialize(stream);
        //using (Stream reader = new StreamReader(stream)
        //{
        //    // Call the Deserialize method to restore the object's state.
        //}
            i = (ExchangeRates)serializer.Deserialize(stream);
        // Write out the properties of the object.
        MessageBox.Show("code: " + i.code + " | rate: " + i.rate);
    }*/
}
        /*public static T GetXmlRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();
                requestUrl = "https://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        xmlOutput = sr.ReadToEnd();
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;
                    else
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }*/
