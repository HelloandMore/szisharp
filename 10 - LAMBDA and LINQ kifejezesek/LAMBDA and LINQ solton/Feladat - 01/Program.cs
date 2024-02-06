using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Feladat___01
{
	internal class Program
	{
		private static List<Player> _players = new List<Player>();

		private static void LoadData()
		{
			using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
			{
				using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
				{
					string jsonData = sr.ReadToEnd();

					_players = JsonConvert.DeserializeObject<List<Player>>(jsonData);
				}
			}
		}

		private static void WriteToConsole(string text, ICollection<Player> players)
		{
			Console.WriteLine(text);
			Console.WriteLine(string.Join('\n', _players));
		}

		private static void WriteToConsole(string text, Player player)
		{
			Console.WriteLine(text);
			Console.WriteLine(player);
		}

		static void Main(string[] args)
		{
			LoadData();
			WriteToConsole("Data", _players);

			// feladat_01
			// hány játékos van az "adatbázis"ban?
			int amountOfPlayers = _players.Count;
			Console.WriteLine($"\nThere are {amountOfPlayers} players in this database");

			// feladat_02
			// játékosok átlagmagassága
			double averageHeight = _players.Average(x => x.Height);
			Console.WriteLine($"The average height of the players in {averageHeight} cm");

			// feladat_03
			// Ki a legalacsonyabb?
			string shortestPlayer = _players.MinBy(x => x.Height).Name;
			Console.WriteLine($"The shortest player is {shortestPlayer}");

			// feladat_04
			// 1980-as születésű játékosok
			List<Player> firstSolBornIn1980s = _players.Where(x => x.Birthday.Substring(0, 4) == "1980").ToList();
			List<Player> secondSolBornIn1980s = _players.Where(x => x.Birthday.StartsWith("1980")).ToList();
			List<Player> thirdSolBornIn1980s = _players.Where(x => x.Birthday.Contains("1980")).ToList();
			List<Player> fourthSolBornIn1980s = _players.Where(x => int.Parse(x.Birthday.Split('.')[0]) == 1980).ToList();
			List<Player> fifthSolBornIn1980s = _players.Where(x => x.Birthday.Split('-')[0] == "1980").ToList();
			List<Player> sixthSolBornIn1980s = _players.Where(x => DateTime.Parse(x.Birthday).Year == 1980).ToList();;

            // feladat_05
            // Játékosok rendezése név szerint csökkenő (Z-A), magasság szerint növekvő sorrendbe
            List<Player> orderByDescNameAscHeight = _players.OrderBy(x => x.Height)
															.ThenByDescending(x => x.Name)
															.ToList();
            Console.WriteLine("Solutions are not printed out (feladat_05)");
            // feladat_06
            // Posztonként hány játékos van?
            List<PlayerByPositions> groupByPoses = _players.GroupBy(x => x.Position)
														  .Select(x => new PlayerByPositions()
														  {
															  Position = x.Key,
															  CountByPos = x.Count(),
														  })
														  .ToList();

			// feladat_07
			// Játékosok, akik az 1990-es években születtek
			List<string> sol1BornIntheNinties = _players.Where(x => x.Birthday.StartsWith("199")).Select(x => x.Name).ToList();
			List<string> sol2BornIntheNinties = _players.Where(x => DateTime.Parse(x.Birthday).Year >= 1990).Select(x => x.Name).ToList();
            Console.WriteLine($"Players born in the '90-s (my sol): {sol1BornIntheNinties}");
			Console.WriteLine($"Players born in the '90-s (teacher sol): {sol2BornIntheNinties}");

			// feladat_08
			// Játékosok csapatonkénti rendezése, majd kiiratása
			// (Gorgi)
			List<Team> playersByTeam = _players.GroupBy(p => p.Club)
											   .Select(p => new Team
											   {
												   Name = p.Key,
												   PlayersName = p.Select(p => p.Name).ToList()
											   })
											   .ToList();

			//foreach (var item in playersByTeam)
			//{
			//	Console.WriteLine(item.Name);

			//	foreach (var item1 in item.PlayersName)
			//	{
			//		Console.WriteLine($"- {item1}");
			//	}
			//	Console.WriteLine();
			//}
			foreach (Team team in playersByTeam)
			{
                Console.WriteLine(team);
            }
		}
	}
}
