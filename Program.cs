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

            // immobili caricati da metodo che accetta lista di immobili come parametro
            List<Immobile> lstImmobili = new List<Immobile>();
            
            Appartamento nuovoAppartamento = new Appartamento("6", "via roma 22", "123444", "Rimini", 600, 6, 3);
            lstImmobili.Add(nuovoAppartamento);
            Box nuovoBox = new Box("7", "via Arcieri 10", "11111", "Padova", 2000, 10);
            lstImmobili.Add(nuovoBox);

            miaAgenzia.AddListaImmobili(lstImmobili);

            Console.WriteLine("____TUTTI GLI IMMOBILI_____");
            foreach (Immobile immobile in miaAgenzia.lstImmobile)
            {
                Console.WriteLine(immobile.ToString());
            }

            Console.WriteLine("\n____IMMOBILI FILTRATI CON 'Roma'_____");
            foreach (Immobile immobile in miaAgenzia.CercaImmobili("Roma"))
            {
                Console.WriteLine(immobile.ToString());
            }
        }
    }
}