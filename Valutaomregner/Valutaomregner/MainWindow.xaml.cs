using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Valutaomregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
 
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
            //new ApiHelper().DeserializeObject("C:/Users/queue/source/repos/Valutaomregner/ExchangeRatesXML.xml");
            //new ApiHelper().SerializeNode("C:/Users/queue/source/repos/Valutaomregner/test.xml");
            //new ApiHelper().SerializeElement("C:/Users/queue/source/repos/Valutaomregner/newTest.xml");
            string filepath = File.ReadAllText(@"C:\Users\queue\source\repos\Valutaomregner\ExchangeRatesXML.xml");
            Currency er = ApiHelper.DeserializeElement<Currency>(filepath);
            Console.Write(er.Code, er.Rate, er.Desc);
            
        }

        public void BindCurrency()
        {
            
            DataTable dtCurrency = new DataTable();
            //Adding columns

            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");
            
            //dtCurrency.Rows.Add(er.Code, er.Rate);
            dtCurrency.Rows.Add();

            //Adding rows

            /*dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("EUR", 7.4429);
            dtCurrency.Rows.Add("USD", 6.3625);
            dtCurrency.Rows.Add("GBP", 8.2349);
            dtCurrency.Rows.Add("SEK", 7.172);
            dtCurrency.Rows.Add("NOK", 6.786);
            dtCurrency.Rows.Add("CHF", 6.9579);
            dtCurrency.Rows.Add("JPY", 0.059955);*/

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;

        }
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;
           
            //Checking if the currency textbox is empty
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                //Error message
                MessageBox.Show("Please enter a value: ", "Information", MessageBoxButton.OK);
                txtCurrency.Focus();
                return;
            }
            //Checking if the From currency combobox has a value that isn't default
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                //Error message
                MessageBox.Show("Pleae enter what currency you're converting from", "Information", MessageBoxButton.OK);
                cmbFromCurrency.Focus();
                return;
            }
            //Checking if the To currency combobox has a value that isn't default
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                //Error message
                MessageBox.Show("Please enter to what currency you're converting to", "Information", MessageBoxButton.OK);
                cmbToCurrency.Focus();
                return;
            }
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                //Here we convert the value which is a string, to a double
                ConvertedValue = double.Parse(txtCurrency.Text);
                //Show the label converted currency and the converted currency's name the N3 is added to add 3 zero's after the .
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                //Conversion formula
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) *
                    double.Parse(txtCurrency.Text)) /
                    double.Parse(cmbToCurrency.SelectedValue.ToString());

                //Displaying the end result
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear_Controls();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Using regex to see if there are only numbers in the textbox
            Regex regex = new Regex("[^0-9]");
            //Checking if its a match   
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void Clear_Controls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }
    }
}
