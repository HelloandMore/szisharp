using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fruit
{
	public string Name {  get; set; }
	public double Weight {  get; set; }
	public double Price {  get; set; }
	
	public Fruit(string name, double weight, double price)
	{
		this.Name = name;
		this.Weight = weight;
		this.Price = price;
	}
	public override string ToString()
	{
		return $"{this.Name} - Ára: {this.Price} - Tömeg: {this.Weight}";
	} 
}
