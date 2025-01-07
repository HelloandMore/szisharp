public abstract class Lakas : Ingatlan
{
	protected double terulet;
	protected int szobaSzam;
	protected int lakok;
	protected int nmAr;

	public Lakas(double terulet, int szobaSzam, int lakok, int nmAr)
	{
		this.terulet = terulet;
		this.szobaSzam = szobaSzam;
		this.lakok = lakok;
		this.nmAr = nmAr;
	}

	public abstract bool Bekoltozik(int emberek);

	public double OsszesKoltseg()
	{
		return terulet * nmAr;
	}

	public int LakokSzama()
	{
		return lakok;
	}

	public override string ToString()
	{
		return $"Terulet: {terulet}, Szobak szama: {szobaSzam}, Lakok szama: {lakok}, Négyzetméter ár: {nmAr}";
	}
}