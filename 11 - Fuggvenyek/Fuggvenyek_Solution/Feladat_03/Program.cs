using System.Drawing;

Point a = GetPoint();
Point b = GetPoint();

int xLenght = Math.Abs(a.X - b.X);
int yLenght = Math.Abs(a.Y - b.Y);

double distance = MathFunctions.Pythagoras(xLenght, yLenght);

Console.WriteLine($"A kettő pont közötti távolság: {distance}");

Point GetPoint() => new Point
{
	X = ExtendedConsole.ReadInteger("x > ", 100),
	Y = ExtendedConsole.ReadInteger("y > ", 100)
};