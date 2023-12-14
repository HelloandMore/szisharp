using IOLibrary;

DailyExpense[] weeklyExpenses = GetDailyExpenses();
Console.Clear();

Console.WriteLine("Weekly expanses: ");
printWeekExptoCon(weeklyExpenses);

// A heti összkiadást
double weeklyExpSum = weeklyExpenses.Sum(DailyExpense => DailyExpense.Expense);
Console.WriteLine($"\n\n All weekly expenses: {weeklyExpSum:F2}");

//Melyik napon volt a legkisebb kiadás és mennyi?
DailyExpense dayWthLeastExpense = getLeastExpensiveDay(weeklyExpenses);
Console.WriteLine($"\n\nLeast expensive day of the week: {dayWthLeastExpense}");

// Volt-e 10000 Ft-os kiadás?
bool expenseWas1000 = weeklyExpenses.Any(x => x.Expense == 10000);
Console.WriteLine($"{(expenseWas1000 ? "Van" : "Nem volt")} 10000 Ft-s kiadás");

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

DailyExpense getLeastExpensiveDay(DailyExpense[] expenses)
{
	int leastExp = expenses.Min(DailyExpense => DailyExpense.Expense);
	DailyExpense dayWthLeast = expenses.First(DailyExpense => DailyExpense.Expense == leastExp);

	return dayWthLeast;
}