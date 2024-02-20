public class Books
{
	public string WriterFirstName { get; set; }
	public string WriterLastName { get; set; }
	public DateTime BirthDate { get; set; }
	public string Title { get; set; }
	public string ISBN { get; set; }
	public string Publisher { get; set; }
	public int PublishYear { get; set; }
	public int Price { get; set; }
	public string Topic { get; set; }
	public int PageCount { get; set; }
	public int Honorarium { get; set; }

	public Books() { }
	//A konyvek.txt állományban az adatok a következő módón vannak tárolva:

	//Vezetéknév(íróé),
	//Keresztnév(íróé),
	//SzületésiDátum,
	//Cím,
	//ISBN,
	//Kiadó,
	//KiadvasiÉv,
	//ár,
	//Téma,
	//Oldalszám,
	//Honorárium (amit a könyvért kapott az író)
	public Books(string writerFirstName, string writerLastName, DateTime birthDate, string title, string isbn, string publisher, int publishYear, int price, string topic, int pageCount, int honorarium)
	{
		WriterFirstName = writerFirstName;
		WriterLastName = writerLastName;
		BirthDate = birthDate;
		Title = title;
		ISBN = isbn;
		Publisher = publisher;
		PublishYear = publishYear;
		Price = price;
		Topic = topic;
		PageCount = pageCount;
		Honorarium = honorarium;
	}

	public override string ToString()
	{
		return $"{WriterFirstName} {WriterLastName} ({BirthDate}) -- {Title} ({PublishYear}) - {Topic} Published by {Publisher}, costing {Price}, Honorarium: {Honorarium}, amount of pages: {PageCount}";
	}
}