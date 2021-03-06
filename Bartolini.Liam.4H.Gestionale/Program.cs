﻿using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;

namespace Bartolini.Liam._4H.Gestionale
{ 
    class Dipendente
    {
        public string cognome;
        public string reparto;
        public int ore;

        public Dipendente()
        {

        }

        public Dipendente(string c, string r, int o)
        {
            cognome = c;
            reparto = r;
            ore = o;
        }

        public int ExtraordinaryHours(int[] ore, string[] reparti, string reparto)
        {
            int oreStrordinarie = 0;

            for(int i = 0; i < ore.Length; i++)
                if (reparti[i] == reparto)
                    oreStrordinarie += ore[i];

            return oreStrordinarie;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Users/Desktop/Desktop/Bartolini.Liam.4H.Gestionale/Bartolini.Liam.4H.Gestionale/dat.txt";
            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Apro il file dati.txt...");
                Console.ResetColor();

                StreamReader fin = new StreamReader(path);

                string riga = fin.ReadLine();
                string[] cognomi_Stream = riga.Split(',');
                riga = fin.ReadLine();
                string[] reparto_Stream = riga.Split(',');
                riga = fin.ReadLine();
                string[] ore_Stream = riga.Split(',');

                fin.Close();
                string ricercaStream;

                while (true)
                {
                    Console.WriteLine("Scegli quale modalità di ricerca usare: \r\n1. Per cognome\r\n2. Per reparto");
                    ricercaStream = Console.ReadLine();

                    if (ricercaStream == "1" || ricercaStream == "2")
                        break;
                }
                
                

                if (ricercaStream == "1")
                {
                    RamoTrue(cognomi_Stream, ore_Stream);
                }

                if (ricercaStream == "2")
                {
                    int[] ore_Int = new int[ore_Stream.Length];

                    for (int i = 0; i < ore_Int.Length; i++)
                        ore_Int[i] = Convert.ToInt32(ore_Stream[i]);

                    RamoFalse(reparto_Stream, ore_Int);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il file non è disponibile...");
                Console.ResetColor();

                string[] cognomi = new string[] { "bartolini", "bronzetti", "lu", "amantini", "tiraferri" };
                string[] reparto = new string[] { "amm", "amm", "magaz", "amm", "sped" };
                int[] ore = new int[] { 2, 6, 3, 7, 9 };
                string[] ore_Int = new string[ore.Length];

                

                string ricerca; 
                while (true)
                {
                    Console.WriteLine("Scegli quale modalità di ricerca usare: \r\n1. Per cognome\r\n2. Per reparto");
                    ricerca = Console.ReadLine();

                    if (ricerca == "1" || ricerca == "2")
                        break;
                }

                if (ricerca == "1")
                {
                    for(int i = 0; i < ore_Int.Length; i++)
                        ore_Int[i] = Convert.ToString(ore[i]);
                    
                    RamoTrue(cognomi, ore_Int);
                }

                if (ricerca == "2")
                {
                    RamoFalse(reparto, ore);
                }
            }
        }

        static void RamoFalse(string[] reparto, int[] ore)
        {
            Dipendente dip = new Dipendente();
            int oreStraodinario = 0;
            bool flag = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hai scelto la seconda opzione!");
            Console.ResetColor();

            Console.WriteLine("Inserisci il reparto da cercare: ");
            string reparto_Ricerca = Console.ReadLine();
            string cognome_Lower = reparto_Ricerca.ToLower();

            for (int i = 0; i < reparto.Length; i++)
            {
                string reparto_Lower = reparto[i].ToLower();
                if (cognome_Lower == reparto_Lower)
                {
                    oreStraodinario += ore[i];
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non è stato trovato nessun reparto..");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"I dipendenti del reparto '{reparto_Ricerca}' hanno fatto {oreStraodinario} ore di straodinario complessive");
                Console.ResetColor();
            }

            int oreExtra = 0;
            //chiamo il metodo per calcolare le ore di straordinario dalla Classe
            oreExtra = dip.ExtraordinaryHours(ore, reparto, reparto_Ricerca);
            Console.WriteLine($"ORE DI STRAORDINARIO CLASSE: {oreExtra}");
            //_____________________________
        }

        static void RamoTrue(string[] cognomi_Stream, string[] ore_Stream)
        {
            bool flag = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hai scelto la prima opzione!");
            Console.ResetColor();

            Console.WriteLine("Inserisci il cognome da cercare: ");
            string cognome = Console.ReadLine();
            string cognome_Lower = cognome.ToLower();

            for (int i = 0; i < cognomi_Stream.Length; i++)
            {
                string cognomi_Lower = cognomi_Stream[i].ToLower();

                if (cognome_Lower == cognomi_Lower)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"il dipendente {cognomi_Stream[i]} ha fatto {ore_Stream[i]} ore di straordinario");
                    flag = true;
                }
            }

            Console.ResetColor();

            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non è stato trovato nessun dipendente...");
                Console.ResetColor();
            }
        }
    }
}