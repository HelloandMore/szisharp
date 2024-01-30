using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Feladat___02
{
    internal class Program
    {
        private static List<Game> _games = new List<Game>();

        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _games = JsonConvert.DeserializeObject<List<Game>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Game> games)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _games));
        }

        private static void WriteToConsole(string text, Game game)
        {
            Console.WriteLine(text);
            Console.WriteLine(game);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _games);

            /*
             Hány adat van a listában?
            */


            /*
             Keressük ki azon játékokat, melyek MMORPG tipusuak (genre).
            */


            /*
            Keressük ki azon játékokat, melyek 2013-ban jelentek meg.
           */

            /*
            Keressük ki azon játékokat, melyek Darkflow Distribution KFR fejlesztett.
           */

            /*
            Keressük ki hány shooter játék van a listában.
           */

            /*
            Van-e olyan játék melyet Cryptic Studios fejleszett?
           */

            /*
            Keressük ki azon játékokat, melyek a címében (title) szerepel a ,,winter,, szó.
           */

            /*
            Keressük ki a platformokat, de úgy, hogy mindegyik csak egyszer forduljon elő az eredménybe.
           */

            /*
            Keressük ki , hogy típusonként (genre) hány játék van.
           */

            /*
            Keressük ki az Electronic Arts álltal fejlesztett játékokat, melyek shooter típusúak.
           */

            /*
            Keressük ki a listában szereplő fejlesztők  játékainak címét.
           */

            /*
            Keressük ki azt a játékot mely legkorábban jelent meg.
           */

            /*
            Keressük ki azon játékok címét, melyeket az Ubisoft jelenített meg, 
            a Blue Byte fejlesztett ki 2010 és 2015 közt.
           */
        }
    }
}
