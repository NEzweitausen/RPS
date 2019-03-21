using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Client
    {
        private string eingabeTCP = "TEST ÜBERMITTLUNG";
        private string ausgabeTCP;
        private string Servername;
        private int ServerPort = 4712;
        private bool running = true;
        private ConsoleColor SchriftSpieler1 = ConsoleColor.Magenta;
        private ConsoleColor SchriftSpieler2 = ConsoleColor.Green;

        private Eingabe e = new Eingabe();

        public Client() //Konstruktor
        {
 
            Console.WriteLine("Die TCP-Verbindung muss aufgebaut werden.\nGeben Sie den Hostnamen ein und bestätigen Sie mit <Enter>.");
            Servername = e.EingabeString();
            
            bool erfolgreich = TCPverbindung();

            if (erfolgreich == false) return;
        }


        private bool TCPverbindung()
        {

            
            TcpClient client = new TcpClient();

            try
            {
                client.Connect(Servername, ServerPort);
            }
            catch (SocketException)
            {
                Console.WriteLine("Fehler bei TCP-Verbindung ! Port:  " + ServerPort);
                return false;
            }
            catch
            {
                Console.WriteLine("Fehler im Verbindungsprozess - nicht TCP an sich.");
            }


            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;

            while (running == true)
            {
                
                //Kommandos analysieren

                Console.WriteLine(ausgabeTCP);
                if (ausgabeTCP == "EXIT") running = false;
                
                if (ausgabeTCP == "1PAPIER")
                {
                    ASCIIart grafikSpieler1 = new ASCIIart(Spielzüge.Papier,SchriftSpieler1);
                }
                else if (ausgabeTCP == "1STEIN")
                {
                    ASCIIart grafikSpieler1 = new ASCIIart(Spielzüge.Stein,SchriftSpieler1);
                }
                else if (ausgabeTCP == "1SCHERE")
                {
                    ASCIIart grafikSpieler1 = new ASCIIart(Spielzüge.Schere,SchriftSpieler1);
                }
                else if (ausgabeTCP == "2PAPIER")
                {
                    ASCIIart grafikSpieler2 = new ASCIIart(Spielzüge.Papier,SchriftSpieler2);
                }
                else if (ausgabeTCP == "2STEIN")
                {
                    ASCIIart grafikSpieler2 = new ASCIIart(Spielzüge.Stein,SchriftSpieler2);
                }
                else if (ausgabeTCP == "2SCHERE")
                {
                    ASCIIart grafikSpieler2 = new ASCIIart(Spielzüge.Schere,SchriftSpieler2);
                }
                else
                {
                    ausgabeTCP = reader.ReadLine();
                }

                eingabeTCP = Console.ReadLine();
                writer.WriteLine(eingabeTCP);
            }

            Console.ReadKey();
            return true;
        }
    }
}
