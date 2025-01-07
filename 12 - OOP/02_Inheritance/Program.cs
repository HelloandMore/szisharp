Cpu i7 = new Cpu("Intel", "i7", "Core", 4, 3.6);
Gpu gpu = new Gpu("Nvidia", "GTX 1080", "Gaming", 8, "GDDR5X");
RamMemory ram = new RamMemory("Corsair", "Vengeance", "DDR4", 16, 2400);

//Hardware hardware = new Hardware; // Error: Cannot create an instance of the ABSTRACT class or interface 'Hardware'

Console.WriteLine(i7);
Console.WriteLine(gpu);
Console.WriteLine(ram);