using System;
using System.IO;

namespace Bartolini.Liam._4H.Gestionale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cognomi = new string[] { "bartolini", "bronzetti", "lu", "amantini", "tiraferri" };
            string[] reparto = new string[] {"amm", "amm", "magaz", "amm", "sped"};
            int[] ore = new int[] {2, 6, 3, 7, 9};

            Console.WriteLine("Scegli quale modalità di ricerca usare: \r\n1. Per cognome\r\n2. Per reparto");
            string ricerca = Console.ReadLine();

            if(ricerca == "1")
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
            else
            {
                int oreStraodinario = 0;
                bool flag = false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hai scelto la seconda opzione!");
                Console.ResetColor();

                Console.WriteLine("Inserisci il reparto da cercare: ");
                string reparto_Ricerca = Console.ReadLine();
                string cognome_Lower = reparto_Ricerca.ToLower();
                
                for(int i = 0; i < reparto.Length; i++)
                {
                    string reparto_Lower = reparto[i].ToLower();
                    if (cognome_Lower == reparto_Lower)
                    {
                        oreStraodinario += ore[i];
                        flag = true;
                    }
                }

                if(!flag)
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