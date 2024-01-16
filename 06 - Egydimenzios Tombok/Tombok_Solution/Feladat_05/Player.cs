using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
	public string Name { get; set; }
	public int NumOfGoals { get; set; }

	public Player(string name, int numOfGoals)
	{
		this.Name = name;
		this.NumOfGoals = numOfGoals;
	}
	public override string ToString()
	{
		return $"{this.Name} - {this.NumOfGoals}";
	}
}
