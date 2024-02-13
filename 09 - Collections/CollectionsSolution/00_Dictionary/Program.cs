Dictionary<string, int> months = new Dictionary<string, int>
{
    { "Januar", 1 }
};

months.Add("Februar", 2);
months["Marcius"] = 3;

//'An item with the same key has already been added. Key: Marcius'
months.Add("Marcius", 2);

if (!months.ContainsKey("Aprilis"))
{
    months.Add("Aprilis", 4);
}

//Uj ertek hozzarendelese a ,,Marcius,, kulcshoz
months["Marcius"] = 3;


foreach (KeyValuePair<string, int> month in months)
{
    Console.WriteLine($"{month.Value} - {month.Key}");
}


Dictionary<string, List<int>> lottoWinners = new Dictionary<string, List<int>>()
{
    { "Hedi", new List<int>{ 4, 5, 6, 7, 8, 9, 10} }
};

lottoWinners.Add("Zalan", new List<int> { 6, 4, 67, 8, 4, 6, 7 });
lottoWinners["Dani"] = new List<int> { 1, 2, 3, 4, 5, 6, 7, };

/*--------------------------------------------------------*/

Dictionary<int, Person> people = new Dictionary<int, Person>()
{
    { 1, new Person {Id = 1 , Name = "Kedd Krisztian"} }
};

people.Add(2, new Person { Id =  2, Name = "Szerda Szilard" });
people[3] = new Person { Id = 3, Name = "Pentek Petra" };


people.Remove(3);
people.Clear();
bool isPersonExists = people.TryGetValue(3, out Person person);

/*--------------------------------------------------------*/
