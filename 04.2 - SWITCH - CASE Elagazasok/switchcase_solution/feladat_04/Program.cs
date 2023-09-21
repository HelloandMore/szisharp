Console.WriteLine("Adj meg két számot egy választható matematikai művelethez");
Console.Write("Első szám > ");
double firstNumber = double.Parse(Console.ReadLine());

Console.Write("\nMásodik szám > ");
double secondNumber = double.Parse(Console.ReadLine());

Console.WriteLine("A kód csak négy különböző műveletet tud végrehajtani: +, -, * és /");
Console.Write("Válassz ezek közül egyet > ");
string equation = Console.ReadLine();

double addition = firstNumber + secondNumber;
double subtraction = firstNumber - secondNumber;
double multiply = firstNumber * secondNumber;
double divide = firstNumber / secondNumber;
string wrong = "Wrong";

double result = equation switch
{
	"+" => addition,
	"-" => subtraction,
	"*" => multiply,
	"/" => divide,
	_ => wrong,
};