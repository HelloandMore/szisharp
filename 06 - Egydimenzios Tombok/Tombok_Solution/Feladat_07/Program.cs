using IOLibrary;

DailyExpense[] weeklyExpenses = GetDailyExpenses();
Console.Clear();

Console.WriteLine("Weekly expanses: ");
printWeekExptoCon(weeklyExpenses);

double weeklyExpSum = weeklyExpenses.Sum(DailyExpense => DailyExpense.Expense);
Console.WriteLine($"\n\n All weekly expenses: {weeklyExpSum:F2}");

DailyExpense dayWthLeast
Console.WriteLine("\n\nLeast amount of expense of the week: ");


Console.ReadKey();

DailyExpense[] GetDailyExpenses()
{
	DailyExpense[] expenses = new DailyExpense[7];
	string[] weekdays = Enum.GetNames(typeof(Days));

	for (int i = 0; i < 7; i++)
	{
		string day = weekdays[i];
		int expense = ExtendedConsole.ReadInteger($"{weekdays[i]}: ", int.MaxValue, 0);
		expenses[i] = new DailyExpense(Enum.Parse<DayOfWeek>(day), expense);
	}
	return expenses;
}

void printWeekExptoCon(DailyExpense[] expenses)
{
	foreach (var expense in expenses)
	{
        Console.WriteLine(expense);
    }
}

DailyExpense dayWthLeastExp(DailyExpense[] expenses)
{
	int leastExp = expenses.Min(DailyExpense => DailyExpense.Expense);
	DailyExpense dayWthLeast = expenses.First(DailyExpense => DailyExpense.Expense == leastExp);

	return dayWthLeast;
}