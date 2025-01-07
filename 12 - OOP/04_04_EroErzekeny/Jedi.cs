public abstract class Jedi : IEroErzekeny
{
	protected float ero;
	protected bool atallhatE;

	public Jedi(float ero, bool atallhatE)
	{
		this.ero = ero;
		this.atallhatE = atallhatE;
	}

	public abstract bool MegteremtiAzEgyensulyt();

	public bool LegyoziE(IEroErzekeny ellenfel)
	{
		if (ellenfel is Jedi)
		{
			Jedi masikJedi = (Jedi)ellenfel;
			if (masikJedi.atallhatE && masikJedi.ero < this.ero)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			Sith uralkodo = (Sith)ellenfel;
			if (this.ero >= 2 * uralkodo.MekkoraAzEreje())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public int MekkoraAzEreje()
	{
		return (int)ero;
	}

	public override string ToString()
	{
		return "Ero: " + ero + ", atallhat-e: " + atallhatE;
	}
}
