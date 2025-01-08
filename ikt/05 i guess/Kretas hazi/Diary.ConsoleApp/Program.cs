using (var db = new ApplicationDbContext())
{
	db.Database.EnsureCreated();
	await Diary.ConsoleApp.DbFunctions.InitAsync(db);

	while (true)
	{
		Console.Clear();
		await Diary.ConsoleApp.DbFunctions.DisplayMainMenuAsync(db);
	}
}