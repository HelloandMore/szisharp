Dictionary<string, int> months = new Dictionary<string, int>()
{
	{ "January", 1 }
};

months.Add("February", 2);
months["March"] = 3;

if(!months.ContainsKey("April"))
{
	months.Add("April", 4);
}

foreach(KeyValuePair<string, int> month in months)
{
    Console.WriteLine($"{month.Value} - {month.Key}");
}

//--------------------------------------------------

Dictionary<string, List<int>> lotteryWinners = new Dictionary<string, List<int>>()
{
	{"Hedi", new List<int>{ 4, 5, 6, 7, 8, 9, 10} }
};

lotteryWinners.Add("Zalan", new List<int> { 6, 4, 67, 8, 4, 6, 7 });
lotteryWinners["Dani"] = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

//---------------------------------------