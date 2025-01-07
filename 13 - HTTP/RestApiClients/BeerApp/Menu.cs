using System.Globalization;

namespace BeerApp;

public static class Menu
{
	public static async Task Main()
	{
		char startingChoice = ExtendedConsole.ReadChar("Sör hozzáadása: 1\nSör keresése: 2\nÖsszes sör listázása: 3\nKilépés: 4\nVálassz > ", ['1', '2', '3', '4']);
		switch (startingChoice)
		{
			case '1':
				await CreateAsync();
				break;
			case '2':
				await Start();
				break;
			case '3':
				Console.WriteLine();
				List<Beer> beers = await BeerService.GetAllAsync();
				foreach (Beer beer in beers)
				{
					beer.WriteToConsole();
				}
				Console.WriteLine();
				await Task.Delay(3000);
				await Main();
				break;
			case '4':
				Console.WriteLine("\nViszlát!");
				await Task.Delay(1000);
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Nem értem a választ, próbáld újra!");
				await Task.Delay(1000);
				await Main();
				break;
		}
		Console.ReadKey();
		Console.Clear();
		await Main();
	}

	public static async Task Start()
	{
		int id = ExtendedConsole.ReadInteger("\nAdd meg a sör azonosítóját > ");
		Console.WriteLine();

		Beer beer = await BeerService.GetByIdAsync(id);

		if (beer is null)
		{
			Console.WriteLine("Nincs ilyen azonosítóval rendelkező sör");
			await Task.Delay(3000);
			await Start();
		}

		AppState.SetBeer(beer);

		UpdateOrDelete();
	}

	public static async Task UpdateOrDelete()
	{
		Beer beer = AppState.GetBeer();
		beer.WriteToConsole();

		Console.WriteLine();
		Console.WriteLine("Törlés: 1");
		Console.WriteLine("Szerkesztés: 2");
		Console.WriteLine("Kilépés: bármi más szám");
		int option = ExtendedConsole.ReadInteger("Válassz egy lehetőséget > ");

		switch (option)
		{
			case 1:
				await DeleteAsync();
				break;
			case 2:
				await UpdateAsync();
				break;
			default:
				Console.Write("\nBiztos kiakarsz lépni? (i / n) > ");
				string answer = Console.ReadLine().ToLower();
				switch (answer)
				{
					case "igen":
						await Main();
						break;
					case "nem":
						await UpdateOrDelete();
						break;
					case "i":
						await Main();
						break;
					case "n":
						await UpdateOrDelete();
						break;
					default:
						Console.WriteLine("Nem értem a választ, próbáld újra!");
						await Task.Delay(3000);
						await UpdateOrDelete();
						break;
				}
				break;
		}
	}

	private static async Task DeleteAsync()
	{
		char toBeDeleted = ExtendedConsole.ReadChar("Biztosan törölni szeretnéd a sört? (i/n) > ", ['i', 'I', 'n', 'N']);

		if (toBeDeleted == 'i' || toBeDeleted == 'I')
		{
			bool isSuccess = await BeerService.DeleteAsync(AppState.GetBeerId());
			Console.WriteLine($"\n{(isSuccess ? "Sikeres" : "Sikertelen")} volt a törlés");

			await Task.Delay(3000);

			await Main();

		}
		else if (toBeDeleted == 'n' || toBeDeleted == 'N')
		{
			return;
		}

	}

	private static async Task CreateAsync()
	{
		Console.Clear();

		Beer newBeer = CreateNewBeer();

		bool isSuccess = await BeerService.SendPostRequestAsync("api/beer/create", newBeer);
		Console.WriteLine($"{(isSuccess ? "Sikeres" : "Sikertelen")} volt a létrehozás");

		await Main();
	}

	private static async Task UpdateAsync()
	{
		Console.Clear();

		Beer updatedBeerData = GetUpdatedBeerData();
		AppState.UpdateBeer(updatedBeerData);

		await BeerService.UpdateAsync(AppState.GetBeer());
	}

	private static Beer GetUpdatedBeerData()
	{
		Beer beer = new Beer();

		Console.Write("Sör neve (lehet üres) > ");
		beer.Name = Console.ReadLine();

		Console.Write("Sör ára (lehet üres) > ");
		string priceString = Console.ReadLine();
		double price = 0;
		if (!string.IsNullOrEmpty(priceString))
		{
			price = double.Parse(priceString, new CultureInfo("en-US"));
			beer.Price = $"${Math.Abs(price)}";
		}


		Console.Write("Sör képe (lehet üres) > ");
		beer.Image = Console.ReadLine();

		AppState.UpdateBeer(beer);

		return AppState.GetBeer();
	}

	private static Beer CreateNewBeer()
	{
		Beer newBeer = new Beer();

		newBeer.Name = ExtendedConsole.ReadString("Sör neve > ");

		string priceString = ExtendedConsole.ReadString("Sör ára > ").Replace(",",".");
		double price = double.Parse(priceString, new CultureInfo("en-US"));
		newBeer.Price = $"${Math.Abs(price)}";

		Console.Write("Sör képe (lehet üres)> ");
		newBeer.Image = Console.ReadLine();

		return newBeer;
	}
}