using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Feladat___03
{
    internal class Program
    {
        private static List<Motorcycle> _motorcycles = new List<Motorcycle>();
        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Motorcycle> motorcycles)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', motorcycles));
        }

        private static void WriteToConsole(string text, Motorcycle motorcycle)
        {
            Console.WriteLine(text);
            Console.WriteLine(motorcycle);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _motorcycles);

            // 1 - Hány motorkerékpár van az 'adatbázisban' ?


            // 2 - Hány 'Honda' gyártmányú motorkerékpár van az 'adatbázisban' ?


            // 3 - Mekkora a legnyaobb köbcenti az 'adatbázisban' ?


            // 4 - Melyik a legkisebb végsebesség az 'adatbázisban' ?


            // 5 - Van e olyan motorkerékpár az 'adatbázisban' amelyet 1960 előtt gyártottak?


            // 6 - Van-e 'Honda' gyártmányú motorkerképár az 'adatbázisban' melynek beceneve 'Hornet' ?


            // 7 - Keressük ki a 'Yamaha' gyártmányú motorkerékpárokat!


            // 8 -Keressük a 'Suzuki' gyártotmányú motorkerékpárokat melyek 600ccm felett vannak!


            // 9 - Keressük ki a 'Kawasaki' gyártotmányú motorkerékpárokat, melyek sebesságe nagyobb min 150km/h!


            // 10 - Keressük ki a 'BMW' gyártotmányú motorkerékpárokat, melyeket 2010 előtt gyárottak és a motor köbcentije minimum 1000!


            // 12 - Keressül a motorkerékpárok beceneveit (nickname)!


            // 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!


            // 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!


            // 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!


            // 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!


            // 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.


            // 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.


            // 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?


            // 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?


            // 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!


            // 22 - Hány kategória található meg az 'adatbázisban'?


            // 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!


            // 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?


            // 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
            //         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
            //         a gyártási évet jelenítse meg!

            Console.ReadLine();
        }
    }
}
