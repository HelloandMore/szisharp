public abstract class Vehicle
{
	/* Az öröklött osztályban felülírhatom, 
	 * de nem vagyok köteles*/
	public virtual void Horn()
	{
		Console.Beep(1000, 800);
	}

	public abstract void Error();
}