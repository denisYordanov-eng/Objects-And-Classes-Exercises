using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rndm = new Random();

            string[] phrases = GetPhrases();
            string[] events = GetEvents();
            string[] authors = GetAuthors();
            string[] cities = GetCities();

            
            int iterations = int.Parse(Console.ReadLine());
            for (int i = 0; i < iterations; i++)
            {
                int phraseIndex = rndm.Next(0, phrases.Length);
                int eventsIndex = rndm.Next(0, events.Length);
                int authorsIndex = rndm.Next(0, authors.Length);
                int cityIndex = rndm.Next(0, cities.Length);

                Console.WriteLine("{0} {1} {2} – {3}.",
                    phrases[phraseIndex],
                    events[eventsIndex],
                    authors[authorsIndex],
                    cities[cityIndex]);
            }
        }

        private static string[] GetPhrases()
        {
            string[] phrasesData = new string[] { "Excellent product.", 
                "Such a great product.",
                "I always use that product."
                , "Best product of its category."
                , "Exceptional product.",
                "I can’t live without this product."};
            return phrasesData;
        }

        private static string[] GetCities()
        {
            string[] cityData = new string[]
            { "Burgas",
              "Sofia",
              "Plovdiv",
              "Varna",
              "Ruse"  };

            return cityData;
        }

        private static string[] GetAuthors()
        {
            string[] autrorsData = new string[]
            { "Diana",
                "Petya",
                "Stella", 
                "Elena", 
                "Katya",
                "Iva",
                "Annie",
                "Eva" };
            return autrorsData;
        }

        private static string[] GetEvents()
        {
            string[] eventsData = new string[] 
            { "Now I feel good.",
           "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"};

            return eventsData;
        }
    }
}
