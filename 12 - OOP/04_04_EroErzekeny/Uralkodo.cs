public class Uralkodo : IEroErzekeny, Sith
{
	private float gonoszsag;

	public Uralkodo()
	{
		gonoszsag = 100;
	}

	public bool LegyoziE(IEroErzekeny ellenfel)
	{
		return ellenfel.MekkoraAzEreje() < gonoszsag ? true : false;
	}

	public int MekkoraAzEreje()
	{
		return (int)(2 * gonoszsag);
	}

	public void EngeddElAHaragod()
	{
		gonoszsag += 50;
	}

	public override string ToString()
	{
		return "Uralkodo, gonoszsag: " + gonoszsag;
	}
}