using System.Text;

public class Worker
{
	private const int MONTHS = 12;

	public string Name { get; set; }

	public double SZJA
	{
		get
		{
			return 0.335 * SalarySum();
		}
	}
	public double TB
	{
		get => SZJA * 0.45;
	}
	public double NYHJ => SZJA * 0.55;

	public int[] Salaries { get; set; }

	public Worker() 
	{
		Salaries = GetSalaries();
	}

	public Worker(string name): this()
	{
		this.Name = name;
	}

	public override string ToString()
	{
		/*string salaries = string.Join("  ",this.Salaries.Select(x => x.ToString()));
		return salaries;*/
		StringBuilder sb = new StringBuilder();
		sb.Append(this.Name);
		sb.Append("\t");

		foreach (var salary in this.Salaries)
		{
			sb.Append(salary.ToString().PadLeft(8)+"Ft");
		}

		return sb.ToString();
	}

	private int SalarySum() => this.Salaries.Sum(x => x);

	private int[] GetSalaries()
	{
		Random rnd = new Random();
		int[] salaries = new int[MONTHS];

		for (int i = 0; i < MONTHS; i++)
		{
			salaries[i] = rnd.Next(210000, 5000000);
		}

		return salaries;
	}
}
