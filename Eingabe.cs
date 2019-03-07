using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{

    class Eingabe
    {
        public double EingabeDouble()
        {
            double parameter = 0;
            bool gültig = false;
            while (gültig == false)
            {
                try
                {
                    parameter = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Diese Eingabe ist ungültig!");
                }
                if (parameter != 0) gültig = true;
            }

            return parameter;
        }

        public int EingabeInt()
        {
            int parameter = 0;
            bool gültig = false;
            while (gültig == false)
            {
                try
                {
                    parameter = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Diese Eingabe ist ungültig!");
                }
                if (parameter != 0) gültig = true;
            }

            return parameter;
        }

        public string EingabeString()
        {
            bool gültig = false;
            string parameter = " ";

            while (gültig == false)
            {
                parameter = Console.ReadLine();
                if (parameter != " " || parameter != "") gültig = true;
            }

            return parameter;
        }
    }
}
