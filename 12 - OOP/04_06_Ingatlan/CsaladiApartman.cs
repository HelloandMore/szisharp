public class CsaladiApartman : Lakas
{
	private int GyerekekSzama;

	public CsaladiApartman(int terulet, int szobaSzam, int nmAr) : base(terulet, szobaSzam, 0, nmAr)
	{
		GyerekekSzama = 0;
	}

	public bool GyerekSzuletik()
	{
		if (lakok < 2)
			return false;
		lakok++;
		GyerekekSzama++;
		return true;
	}

	public override bool Bekoltozik(int emberek)
	{
		if (emberek > 8 || terulet / emberek < 2 || emberek > 2 && terulet / emberek < 10)
			return false;
		lakok = emberek;
		return true;
	}

	public override string ToString()
	{
		return base.ToString() + $", Gyerekek szama: {GyerekekSzama}";
	}
}