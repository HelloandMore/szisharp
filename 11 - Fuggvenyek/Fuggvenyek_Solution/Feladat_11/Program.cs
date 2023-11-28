using IOLibrary;

const int BASE_WORKING_HOURS = 40;

string nameOfWorker = ExtendedConsole.ReadString("Add meg a dolgozó nevét > ");
double workersWorkingHours = ExtendedConsole.ReadDouble("Add meg mennyit dolgozott > ");

double regularPayment = CalculatePayment(BASE_WORKING_HOURS);
double overtimePayment = workersWorkingHours > BASE_WORKING_HOURS ? CalculatePayment(workersWorkingHours - BASE_WORKING_HOURS, 1500) : 0;

double payment = regularPayment + overtimePayment;

Console.WriteLine($"{nameOfWorker} fizetése: {payment} HUF");
Console.ReadKey();


double CalculatePayment(double workingHours, int wage = 1000) => workingHours * wage;