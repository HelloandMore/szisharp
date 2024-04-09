using IOLibrary;
namespace BeerApp
{
	public static class Menu
	{
		public static async void Main()
		{
			int id = ExtendedConsole.ReadInteger("Enter the ID of the beer > ");

			Beer beer = await BeerService.GetByIdAsync(id);
		}
	}
}
