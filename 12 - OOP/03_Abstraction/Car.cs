public class Car : Vehicle
{
	public override void Error()
	{
		for (int i = 0; i < 3; i++)
		{
			Console.Beep(500, 500);
		}
	}
}