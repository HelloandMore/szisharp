public class Garazs : Ingatlan, Berelheto
{
	private int terulet;
	private int nmAr;
	private bool futott;
	private int foglaltHonapok;
	private bool auto;

	public Garazs(int terulet, int nmAr, bool futott)
	{
		this.terulet = terulet;
		this.nmAr = nmAr;
		this.futott = futott;
		foglaltHonapok = 0;
		auto = false;
	}

	public int OsszesKoltseg()
	{
		return terulet * nmAr;
	}

	public int MennyibeKerul(int honapok)
	{
		if (auto)
			return terulet * nmAr * 3 / 2 * honapok;
		return terulet * nmAr * honapok;
	}

	public bool LefoglaltE()
	{
		return foglaltHonapok != 0 || auto;
	}

	public bool Lefoglal(int honapok)
	{
		if (foglaltHonapok != 0 || auto)
			return false;
		foglaltHonapok = honapok;
		return true;
	}

	public void AutoKiBeAll()
	{
		auto = !auto;
	}

	public override string ToString()
	{
		return $"Terulet: {terulet}, Négyzetméter ár: {nmAr}, Fűtött: {(futott ? "igen" : "nem")}, Foglalt hónapok: {foglaltHonapok}, Autó: {(auto ? "van" : "nincs")}";
	}
}