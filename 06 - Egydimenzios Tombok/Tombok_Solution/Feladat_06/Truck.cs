using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Truck
{
	public string LicensePlate { get; set; }
	public int Weight { get; set; }

	public Truck(string licensePlate, int weight)
	{
		this.LicensePlate = licensePlate;
		this.Weight = weight;
	}

	public override string ToString()
	{
		return $"{this.LicensePlate} rendszámú kamion ({this.Weight}T)";
	}

}