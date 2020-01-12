using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp1.Model;

namespace GeneratorCekacichSmycekDoAsm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Generator generator;
        public MainWindow()
        {
            InitializeComponent();
            generator = new Generator();
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {
            if (TryFloat(T.Text) != -1 && TryFloat(Fosc.Text) != -1 && TryInt(Nic.Text) != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    vypis(openFileDialog.FileName, generator.vypis(TryFloat(T.Text), TryFloat(Fosc.Text), TryInt(Nic.Text)));
                    MessageBox.Show("Kód byl úspěšně vygenerován!", "Success");
                }
            }
            else { MessageBox.Show("Překontrolujte si zadané hodnoty!!!", "Error"); }
        }

        float TryFloat(string num)
        {

            float number;
            bool success = float.TryParse(num, out number);
            if (success)
            {
                return number;
            }
            else
            {
                string error = ("Attempted conversion of " + num + " failed.");
                MessageBox.Show(error, "ERROR!");
                return -1;
            }


        }
        int TryInt(string num)
        {
            int number;
            bool success = Int32.TryParse(num, out number);
            if (success)
            {
                return number;
            }
            else
            {
                string error = ("Attempted conversion of " + num + " failed.");
                MessageBox.Show(error, "ERROR!");
                return -1;
            }


        }

        public void vypis(string path, string vystup)
        {
            File.WriteAllText(path, vystup);
        }
    }
}
