using System;

namespace csharp_agenzia 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Agenzia miaAgenzia = new Agenzia("VendiCasa");
            miaAgenzia.AddAppartamento("1", "via cirino", "12345", "Roma", 100, 1, 1);
            miaAgenzia.AddVilla("2", "via cirino", "89345", "MILANO", 200, 4, 2, 100);
            miaAgenzia.AddBox("3", "via Roma", "76431", "MILANO", 100, 2);
            miaAgenzia.AddBox("4", "via cirino", "14567", "Roma", 100, 2);
            miaAgenzia.AddAppartamento("5", "via cirino", "12345", "MILANO", 200, 4, 2);

            Console.WriteLine("____TUTTI GLI IMMOBILI_____");
            foreach (Immobile immobile in miaAgenzia.lstImmobile)
            {
                Console.WriteLine(immobile.ToString());
            }

            Console.WriteLine("____IMMOBILI FILTRATI CON 'Roma'_____");
            foreach (Immobile immobile in miaAgenzia.CercaImmobili("Roma"))
            {
                Console.WriteLine(immobile.ToString());
            }
        }
    }
}