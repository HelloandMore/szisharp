using System.Diagnostics;
using System.Threading.Channels;
using System.Globalization;

namespace BeerApp;

public static class Menu
{
    public static async Task Main()
    {
        int id = ExtendedConsole.ReadInteger("\nAdd meg a sör azonosítósát > ");

        Beer beer = await BeerService.GetByIdAsync(id);

        if (beer is null)
        {
			Console.WriteLine("\nNincs ilyen azonosítóval rendelkező sör");
			await Task.Delay(3000);
            await Main();
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
        int option = ExtendedConsole.ReadInteger("Válassz egy lehetőséget > ");

        switch (option)
        {
			case 1:
				await DeleteAsync();
				break;
			case 2:
				await UpdateAsync();
				break;
		}
    }

    private static async Task DeleteAsync()
    {
        char toBeDeleted = ExtendedConsole.ReadChar("Biztosan törölni szeretnéd a sört? (i/n) > ", ['i', 'I', 'n', 'N']);

        if(toBeDeleted == 'i' || toBeDeleted == 'I')
        {
			bool isSuccess = await BeerService.SendDeleteRequestAsync("api/beer/delete", AppState.GetBeerId());
            Console.WriteLine($"{(isSuccess ? "Sikeres" : "Sikertelen")} volt a törlés");

            await Task.Delay(3000);

            await Main();

		} else if (toBeDeleted == 'n' || toBeDeleted == 'N')
        {
            return;
        }

    }

    private static async Task UpdateAsync()
    {
        Console.Clear();

        Beer updatedBeerData = GetUpdatedBeerData();
        AppState.UpdateBeer(updatedBeerData);

        await BeerService.SendPutRequestAsync("api/beer/update", AppState.GetBeer());
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


}
