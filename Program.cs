using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Eingabe e = new Eingabe();

            

            while (true)
            {
                Console.WriteLine("Willkommen bei Schere, Stein, Papier...  \nWählen Sie zwischen Einzelmodus und Mehrspielermodus mit <E> und <M>.");

                string wahl = e.EingabeString();

                if (wahl == "E")
                {
                    Game game = new Game();

                }
                else if (wahl == "M")
                {
                    Client client = new Client();
                }
            }



        }
    }




}
