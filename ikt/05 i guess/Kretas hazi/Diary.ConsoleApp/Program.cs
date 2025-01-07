using (var db = new ApplicationDbContext())
{
	db.Database.EnsureCreated();
	await Diary.ConsoleApp.DbFunctions.AssignAddressesToAllStudentsAsync(db);

	while (true)
	{
		Console.Clear();
		await Diary.ConsoleApp.DbFunctions.DisplayMainMenuAsync(db);
	}
}