using IOLibrary;

double squareMeter = ExtendedConsole.ReadDouble("Adja meg a fal területét > ");

double paintAmount = GetPaintAmount(squareMeter);
double paintCost = GetPaintCost(paintAmount);

Console.Write($"{squareMeter} négyzetméter fal festéséhez {paintAmount}L festék kell, ami");
Console.WriteLine($" ára összesen: {paintCost:F2} HUF");

double GetPaintAmount(double squareMeter) => squareMeter * 0.15;

double GetPaintCost(double paintAmount) => Math.Ceiling(paintAmount) * 930;