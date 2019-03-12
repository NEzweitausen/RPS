using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{

    enum Spielzüge { Schere, Stein, Papier };

    class Game
    {
        private Spieler spieler = new Spieler();
        private Spieler computer = new Spieler();
        private Spielzüge Benutzer;
        private Spielzüge LastBenutzer;
        private Spielzüge Gegner;
        private Random random = new Random();
        private int CountMehrfacherSpielzug = 0;
        private int CountExit = 0;

        public Game() //Konstruktor
        {

            spieler.SETname("test");
            computer.SETname("computer");

            userinterface();
        }

     

        public void userinterface()
        {

            Eingabe e = new Eingabe();
            bool running = true;


            do
            {
                Console.WriteLine("Sie haben folgende Optionen: \n1 - Schere \n2 - Stein \n3 - Papier");

                Console.WriteLine("Geben Sie ihren Zug ein");
                
                int ZugBenutzer = 0;
                bool ungültig = false;

                do
                {
                    ZugBenutzer = e.EingabeInt(); //Benutzereingabe
                    ungültig = false;

                    if (ZugBenutzer > 3 || ZugBenutzer < 1)
                    {
                        ungültig = true;
                        Console.WriteLine("Ungültiger Zug!");
                    }


                } while (ungültig == true);


                int ZugComputer = random.Next(1, 4); //Obere Grenze einen Wert über dem Zahlenbereich, Untere Grenze im Zahlenbereich !!!

                bool entschieden = Auswertung(ZugBenutzer, ZugComputer);

                if (entschieden == true)
                {
                    if (Gegner == Spielzüge.Papier) Console.WriteLine("Der Gegner hat Papier genommen.");
                    if (Gegner == Spielzüge.Stein) Console.WriteLine("Der Gegner hat sich für Stein entschieden.");
                    if (Gegner == Spielzüge.Schere) Console.WriteLine("Der Gegner hat Schere gewählt. \n");

                    if (Benutzer == Spielzüge.Papier) Console.WriteLine("Ihr Zug: Papier");
                    if (Benutzer == Spielzüge.Stein) Console.WriteLine("Ihr Zug: Stein");
                    if (Benutzer == Spielzüge.Schere) Console.WriteLine("Ihr Zug: Schere \n");

                }
                else
                {
                    Console.WriteLine("Unentschieden!");
                }

                Console.WriteLine("Der aktuelle Spielstand: \nComputer: " + computer.GETspielstand() + "\n" + spieler.GETname() + ": " + spieler.GETspielstand() + "\n");

                CountExit++;

                if (CountExit >= 8)
                {
                    Console.WriteLine("Geben Sie zum verlassen des Spiels das Schlüsselwort <exit> ein.");
                    if (e.EingabeString() == "exit") running = false;
                    CountExit = 0;
                }

            
            } while (running);


        }

        public Spielzüge Übersetzung(int ZugBenutzer)
        {
            Spielzüge Eingabe = new Spielzüge();

            if (ZugBenutzer == 1) Eingabe = Spielzüge.Schere;
            if (ZugBenutzer == 2) Eingabe = Spielzüge.Stein;
            if (ZugBenutzer == 3) Eingabe = Spielzüge.Papier;

            return Eingabe;
        }

        public bool Auswertung(int ZugBenutzer, int ZugGegner)
        {

            Benutzer = Übersetzung(ZugBenutzer);
            Gegner = Übersetzung(ZugGegner);


            if (LastBenutzer == Benutzer)
            {
                CountMehrfacherSpielzug++;

                if (CountMehrfacherSpielzug >= 3)
                {

                    Console.WriteLine("\nLangweilig... \nDer Computer hat deine Strategie entlarvt.\n");

                    if (Benutzer == Spielzüge.Schere) Gegner = Spielzüge.Stein;
                    if (Benutzer == Spielzüge.Stein) Gegner = Spielzüge.Papier;
                    if (Benutzer == Spielzüge.Papier) Gegner = Spielzüge.Schere;
                }

                
            }
            else
            {
                CountMehrfacherSpielzug = 0;
            }

            if (Benutzer == Gegner)
            {
                return false;
            }

            if (Benutzer == Spielzüge.Schere && Gegner == Spielzüge.Stein) computer.SETspielstand(computer.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Schere && Gegner == Spielzüge.Papier) spieler.SETspielstand(spieler.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Stein && Gegner == Spielzüge.Schere) spieler.SETspielstand(spieler.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Stein && Gegner == Spielzüge.Papier) computer.SETspielstand(computer.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Papier && Gegner == Spielzüge.Schere) computer.SETspielstand(computer.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Papier && Gegner == Spielzüge.Stein) spieler.SETspielstand(spieler.GETspielstand() + 1);


            
            LastBenutzer = Benutzer;

            return true;

        }

    }
}
