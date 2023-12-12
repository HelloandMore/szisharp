public class DailyExpense
{
	public DayOfWeek Day { get; set; }

	public int Expense { get; set; }

	public DailyExpense(DayOfWeek day, int expense)
	{
		this.Day = day;
		this.Expense = expense;
	}

	public override string ToString()
	{
		return $"{this.Day} => {this.Expense}";
	}
}