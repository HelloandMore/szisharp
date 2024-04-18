public class Truck : Car
{
	/* Az öröklött osztályban felülírhatom, 
	 * 	 * de nem vagyok köteles*/
	public override void Horn()
	{
		Console.Beep(200, 1000);
	}

	public override void Error()
	{
		for (int i = 0; i < 3; i++)
		{
			Console.Beep(200, 500);
		}
	}
}