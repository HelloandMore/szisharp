//parameter nelkuli konstruktor hasznalata peldanyositaskor
Fruit apple = new Fruit();
apple.Name = "apple";
apple.Calories = 60;
apple.Price = 450;
apple.Importers.Add("ABCS");
//apple.Importers = new List<string>(); //private set miatt
//apple.hasImporters = true; //readonly miatt

Fruit orange = new Fruit
{
	Name = "orange",
	Calories = 90,
	Price = 380
};

//peldanyositas parameteres konstruktorokkal
Fruit banana = new Fruit("banana", 89, 600);

Fruit gala = new Fruit(apple);