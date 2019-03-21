using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class ASCIIart
    {
        private Spielzüge spielzug;
        private ConsoleColor farbe;
        private bool farbeISSET;

        public ASCIIart(Spielzüge spielzug, ConsoleColor farbe)
        {
            this.spielzug = spielzug;
            this.farbe = farbe;
            farbeISSET = true;
            Zeichnen();
        }
        public ASCIIart(Spielzüge spielzug)
        {
            this.spielzug = spielzug;
            farbeISSET = false;
            Zeichnen();
        }

        private void Zeichnen()
        {
            string output;

            if (spielzug == Spielzüge.Papier)
            {
                output = File.ReadAllText(@"F:\LF 6 Datenbanken und programmieren\Agiles Projekt LF6\RPS\RPS\PAPIER.txt"); //TODO: Variabel mappen
            }
            else if (spielzug == Spielzüge.Schere)
            {
                output = File.ReadAllText(@"F:\LF 6 Datenbanken und programmieren\Agiles Projekt LF6\RPS\RPS\SCHERE.txt");
            }
            else
            {
                output = File.ReadAllText(@"F:\LF 6 Datenbanken und programmieren\Agiles Projekt LF6\RPS\RPS\STEIN.txt");
            }

            if (farbeISSET == true) Console.ForegroundColor = farbe;
            Console.WriteLine(output);
            if (farbeISSET == true) Console.ResetColor();
        }
    }
}
