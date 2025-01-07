Console.SetWindowSize(210, 90);
Console.WriteLine("Car driver uses their horn");
Car car = new Car();
SignalVehicleError(car);
// car.Horn();
//car.Error();

await Task.Delay(1000);

Console.WriteLine("Truck driver uses their horn");
Truck truck = new Truck();
SignalVehicleError(truck);
// truck.Horn();
//truck.Error();

await Task.Delay(1000);

//void SignalVehicleError(Truck truck)
//{
//	truck.Error();
//}

//fenti helyett:

void SignalVehicleError(Vehicle vehicle) => vehicle.Error();