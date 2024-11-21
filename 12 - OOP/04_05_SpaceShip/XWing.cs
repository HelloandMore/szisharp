public class XWing : LazadoGep, IHiperhajtomu
{
	public XWing() : base(150, true)
	{
	}

	public void HiperUgras()
	{
		Random rnd = new Random();
		sebesseg += (float)rnd.NextDouble() * 100;
	}

	public override bool ElkapjaAVonosugar()
	{
		return meghibasodhatE && sebesseg < 10000;
	}

	public override string ToString()
	{
		return $"X-Wing: {base.ToString()}";
	}
}