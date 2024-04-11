namespace BeerApp;

public static class AppState
{
	private static Beer selectedBeer;

	public static void SetBeer(Beer beer) => selectedBeer = beer;

	public static void ClearBeer() => selectedBeer = null;

	public static Beer GetBeer() => selectedBeer;

	public static void UpdateBeer(Beer beer)
	{
		selectedBeer.Image = string.IsNullOrWhiteSpace(beer.Image) ? selectedBeer.Image : beer.Image;

		selectedBeer.Name = string.IsNullOrWhiteSpace(beer.Name) ? selectedBeer.Name : beer.Name;

		selectedBeer.Price = string.IsNullOrEmpty(beer.Price) ? selectedBeer.Price : beer.Price;
	}

	public static int GetBeerId() => selectedBeer.Id;
}