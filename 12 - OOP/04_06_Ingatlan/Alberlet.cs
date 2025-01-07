public class Alberlet : Lakas, Berelheto
{
	private int foglaltHonapok;

	public Alberlet(double terulet, int szobaSzam, int lakok, int nmAr) : base(terulet, szobaSzam, lakok, nmAr)
	{
		this.foglaltHonapok = 0;
	}

	public int MennyibeKerul(int honapok)
	{
		if (lakok == 0)
			return -1;
		return OsszesKoltseg() / lakok * honapok;
	}

	public bool LefoglaltE()
	{
		return foglaltHonapok != 0;
	}

	public bool Lefoglal(int honapok)
	{
		if (foglaltHonapok != 0)
			return false;
		foglaltHonapok = honapok;
		return true;
	}

	public override bool Bekoltozik(int emberek)
	{
		if (emberek > 8 || terulet / emberek < 2)
			return false;
		lakok = emberek;
		return true;
	}

	public override string ToString()
	{
		return base.ToString() + $", Foglalt honapok: {foglaltHonapok}";
	}
}