public class MilleniumFalcon : IUrhajo, IHiperhajtomu
{
	private float tapasztalat;

	public MilleniumFalcon()
	{
		tapasztalat = 100;
	}

	public void HiperUgras()
	{
		tapasztalat += 500;
	}

	public bool LegyorsuljaE(IUrhajo hajo)
	{
		if (hajo is LazadoGep)
		{
			LazadoGep hajo2 = (LazadoGep)hajo;
			if (hajo2.MilyenGyors() < tapasztalat * 2)
			{
				return true;
			}
		}
		return false;
	}

	public int MilyenGyors()
	{
		return (int)(tapasztalat * 2);
	}

	public override string ToString()
	{
		return $"Millenium Falcon: Tapasztalat: {tapasztalat}";
	}
}