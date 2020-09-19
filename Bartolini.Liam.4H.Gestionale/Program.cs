using System;
using System.IO;

namespace Bartolini.Liam._4H.Gestionale
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Users/Desktop/Desktop/Bartolini.Liam.4H.Gestionale/Bartolini.Liam.4H.Gestionale/dati.txt";
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

                Console.WriteLine("Scegli quale modalità di ricerca usare: \r\n1. Per cognome\r\n2. Per reparto");
                string ricercaStream = Console.ReadLine();

                if(ricercaStream == "1")
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
               
                if(ricercaStream == "2")
                {
                    int oreStraodinario = 0;
                    bool flag = false;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hai scelto la seconda opzione!");
                    Console.ResetColor();

                    Console.WriteLine("Inserisci il reparto da cercare: ");
                    string reparto_Ricerca = Console.ReadLine();
                    string cognome_Lower = reparto_Ricerca.ToLower();

                    for (int i = 0; i < reparto_Stream.Length; i++)
                    {
                        string reparto_Lower = reparto_Stream[i].ToLower();
                        if (cognome_Lower == reparto_Lower)
                        {
                            oreStraodinario += Convert.ToInt32(ore_Stream[i]);
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

                Console.WriteLine("Scegli quale modalità di ricerca usare: \r\n1. Per cognome\r\n2. Per reparto");
                string ricerca = Console.ReadLine();

                if (ricerca == "1")
                {
                    bool flag = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hai scelto la prima opzione!");
                    Console.ResetColor();

                    Console.WriteLine("Inserisci il cognome da cercare: ");
                    string cognome = Console.ReadLine();
                    string cognome_Lower = cognome.ToLower();

                    for (int i = 0; i < cognomi.Length; i++)
                    {
                        string cognomi_Lower = cognomi[i].ToLower();

                        if (cognome_Lower == cognomi_Lower)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"il dipendente {cognomi[i]} ha fatto {ore[i]} ore di straordinario");
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
                
                if(ricerca == "2")
                {
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
                }
            }
        }
    }
}