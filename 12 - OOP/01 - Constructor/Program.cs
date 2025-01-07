// Ár HUF-ban
// Paraméter nélküli konstruktor hívása
Fruit apple = new Fruit();
apple.Name = "Apple";
apple.Calories = 52;
apple.Price = 300;
apple.Importers.Add("ABCDS");
// apple.Importers = new List<string>(); // "accessor is inaccessible" hiba

Fruit orange = new Fruit 
{
	Name = "Orange",
	Calories = 47,
	Price = 250
};

// Paraméteres konstruktor hívása
Fruit banana = new Fruit("Banana", 89, 600);

Fruit gala = new Fruit(apple);