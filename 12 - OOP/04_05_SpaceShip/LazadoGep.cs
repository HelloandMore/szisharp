public abstract class LazadoGep : IUrhajo
{
	protected float sebesseg;
	protected bool meghibasodhatE;

	public LazadoGep(float sebesseg, bool meghibasodhatE)
	{
		this.sebesseg = sebesseg;
		this.meghibasodhatE = meghibasodhatE;
	}

	public abstract bool ElkapjaAVonosugar();

	public bool LegyorsuljaE(IUrhajo hajo)
	{
		if (hajo is LazadoGep)
		{
			LazadoGep hajo2 = (LazadoGep)hajo;
			if (hajo2.meghibasodhatE && hajo2.sebesseg < sebesseg)
			{
				return true;
			}
			else if (hajo2 is MilleniumFalcon && hajo2.sebesseg < sebesseg * 2)
			{
				return true;
			}
		}
		return false;
	}

	public int MilyenGyors()
	{
		return (int)sebesseg;
	}

	public override string ToString()
	{
		return $"Sebesség: {sebesseg}, Meghibásodhat: {meghibasodhatE}";
	}
}