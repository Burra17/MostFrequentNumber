using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

namespace MostFrequentArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Strategi: Jag tänker använda en Dictionary<int, int> för att räkna hur många gånger varje siffra förekommer i arrayen. 
            //Nyckeln blir själva siffran och värdet blir antalet gånger den dyker upp.

            //Struktur: Jag kommer köra en foreach-loop genom hela arrayen först för att fylla min Dictionary.

            //Logik för att hitta rätt tal: Efter loopen går jag igenom alla sparade siffror. 
            //Jag skapar två variabler: en för att hålla koll på vilket tal som leder(vinnare) och en för hur många gånger det talet fanns(maxAntal).

            //Specialfall(lika frekvens): Om jag hittar ett tal som har exakt samma antal förekomster som det nuvarande ledande talet,
            //lägger jag till en extra koll(if-sats) för att se vilket av talen som är minst, och sparar det minsta.


            // Testfall 1
            int[] test1 = { 1, 3, 2, 3, 4, 1, 3, 2, 2, 2, 5 };
            Console.WriteLine($"Test 1: Förväntat: 2, Resultat: {MestFrekventSiffra(test1)}");

            // Testfall 2
            int[] test2 = { 7, 7, 5, 5, 1, 1, 1, 2, 2, 2 };
            Console.WriteLine($"Test 2: Förväntat: 1, Resultat: {MestFrekventSiffra(test2)}");

            // Testfall 3 (Negativa tal)
            int[] test3 = { -1, -1, -5, -5, -5, 2, 2 };
            Console.WriteLine($"Test 3: Förväntat: -5, Resultat: {MestFrekventSiffra(test3)}");
        }

        public static int MestFrekventSiffra(int[] arr)
        {
            // Kontrollera om listan är tom för att undvika fel
            if (arr == null || arr.Length == 0) return 0;

            // Skapa en Dictionary för att lagra 'Talet' (Key) och 'Antal gånger det dykt upp' (Value)
            Dictionary<int, int> count = new Dictionary<int, int>();

            // Steg 1: Fyll Dictionaryn genom att loopa igenom hela arrayen
            foreach (int tal in arr)
            {
                if (count.ContainsKey(tal))
                {
                    // Om talet redan finns som nyckel, öka dess värde med 1
                    count[tal]++;
                }
                else
                {
                    // Om talet är nytt, lägg till det och sätt antalet till 1
                    count[tal] = 1;
                }
            }

            // Steg 2: Hitta vinnaren genom att loopa igenom vår Dictionary
            int vinnandeTal = arr[0]; // Starta med första talet som en kandidat
            int maxAntal = 0;         // Håll koll på den högsta frekvensen vi hittat hittills

            foreach (var entry in count)
            {
                int nuvarandeTal = entry.Key;     // Siffran
                int nuvarandeAntal = entry.Value; // Hur många gånger siffran fanns

                // Här kollar vi två saker:
                // 1. Är detta tal vanligare än det vi hittat förut?
                // 2. ELLER: Är det lika vanligt, men själva siffran är lägre? (Enligt uppgiftens regler)
                if (nuvarandeAntal > maxAntal || (nuvarandeAntal == maxAntal && nuvarandeTal < vinnandeTal))
                {
                    maxAntal = nuvarandeAntal; // Uppdatera rekordet för antal
                    vinnandeTal = nuvarandeTal; // Uppdatera vem som leder
                }
            }

            // Returnera det tal som vann
            return vinnandeTal;
        }
    }
}
