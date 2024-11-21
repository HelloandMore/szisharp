public class AnakinSkywalker : Jedi, Sith
{
	public AnakinSkywalker() : base(150, true)
	{
	}

	public void EngeddElAHaragod()
	{
		Random rnd = new Random();
		ero += (float)rnd.NextDouble() * 10;
	}

	public override bool MegteremtiAzEgyensulyt()
	{
		if (ero > 1000)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override string ToString()
	{
		return "Anakin Skywalker, " + base.ToString();
	}
}