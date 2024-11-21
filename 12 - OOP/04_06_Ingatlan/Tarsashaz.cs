public class Tarsashaz
{
	private List<Ingatlan> ingatlanok;
	private int maxLakas;
	private int maxGarazs;

	public Tarsashaz(int maxLakas = int.MaxValue, int maxGarazs = int.MaxValue)
	{
		ingatlanok = new List<Ingatlan>();
		this.maxLakas = maxLakas;
		this.maxGarazs = maxGarazs;
	}

	public bool LakasHozzaad(Lakas lakas)
	{
		if (ingatlanok.Count(x => x is Lakas) >= maxLakas)
			return false;
		ingatlanok.Add(lakas);
		return true;
	}

	public bool GarazsHozzaad(Garazs garazs)
	{
		if (ingatlanok.Count(x => x is Garazs) >= maxGarazs)
			return false;
		ingatlanok.Add(garazs);
		return true;
	}

	public int OsszesLako()
	{
		return ingatlanok.Where(x => x is Lakas).Sum(x => (x as Lakas).LakokSzama());
	}

	public int IngatlanErtek()
	{
		return ingatlanok.Sum(x => x.OsszesKoltseg());
	}

}