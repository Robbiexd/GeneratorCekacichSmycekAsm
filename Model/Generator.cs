using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Model
{
    public class Generator
    {
        
        const string tab = "                ";   
        
        public Generator()
        {
                
        }

        public string vypis(float t, float Fosc, int Nic)
        {
            string hex = zpracuj(t, Fosc, Nic);

            //pripraveni vstupu pro vypsani na vystup
            if(hexCount(hex) % 2 != 0)
            {
                hex = "0" + hex;
            }

            List<char> l1 = new List<char>();
            List<char> l2 = new List<char>();
            
            int numOfLoops = 0;
            foreach (char i in hex)
            {   
                if(numOfLoops % 2 == 0)
                { l1.Add(i);  }
                else { l2.Add(i); }
                numOfLoops++;
            }


            //generace vystupu
            string output = "";
            string zbytek_kodu = "cekej0: ";
            int citac = 0;
            //int cr = 16; citac0 = registr 16
            for (int i = 0; i < hexCount(hex); i++)
            {
                if (i <= l1.Count - 1 && i <= l2.Count - 1)
                { output += "LDI citac" + i + tab + "0x" + l1[i] + l2[i] + '\n'; }
                
                if (i == 1) { zbytek_kodu += "?BRPL"; }
 
                if (i % 2 != 0)
                { 
                   zbytek_kodu += tab + "DEC citac" + citac + '\n'; citac++;
                }
                else { zbytek_kodu += tab + "BRNE cekej0" + '\n'; }

                if (hexCount(hex) == 2)
                { break; }
            }
            //cr = 0;
            return string.Format(output + zbytek_kodu);
        }


        //vypocitani hexa hodnoty ze vstupu
        public string zpracuj(float t, float Fosc, int Nic)
        {
            float Tic;
            float Fic;
            float N;
            string N_Hex;
            Fic = (Fosc / Nic);
            Tic = 1 / Fic;
            N = (t / Tic);
            int decValue = (int)(N / 3);
            N_Hex = decValue.ToString("X");
            //MessageBox.Show("Fic is " + Fic + "Tic is  " + Tic + "N is " + N + "N_HEx is" + N_Hex);
            return N_Hex;
        }

        //vrati pocet cislic hexa hodnoty
        public int hexCount(string hex)
        {
            int hex_count = 0;
            foreach(char c in hex)
            {
                hex_count++;
            }
            return hex_count;
        }
    }
}
