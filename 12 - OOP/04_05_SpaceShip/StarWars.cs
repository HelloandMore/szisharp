public class StarWars
{
	private static List<IUrhajo> urhajok = new List<IUrhajo>();
	public static void Urhajok(string path)
	{
		try
		{
			StreamReader sr = new StreamReader("../../../source/" + path);
			while (!sr.EndOfStream)
			{
				string[] sor = sr.ReadLine().Split(' ');
				if (sor[0] == "XWing")
				{
					XWing xwing = new XWing();
					for (int i = 0; i < int.Parse(sor[1]); i++)
					{
						xwing.HiperUgras();
					}
					urhajok.Add(xwing);
				}
				else if (sor[0] == "MilleniumFalcon")
				{
					MilleniumFalcon mf = new MilleniumFalcon();
					for (int i = 0; i < int.Parse(sor[1]); i++)
					{
						mf.HiperUgras();
					}
					urhajok.Add(mf);
				}
			}
			sr.Close();
		}
		catch (IOException e)
		{
			Console.WriteLine(e.Message);
		}
	}

	public static void Hangar()
	{
		foreach (IUrhajo urhajo in urhajok)
		{
			Console.WriteLine(urhajo);
		}
	}

	public static void Main()
	{
		Urhajok("urhajok.txt");
		Hangar();
	}
}