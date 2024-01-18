using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Song
{
	public string Name {  get; set; }
	public int Length {  get; set; }
	public int Placement { get; set; }
	internal int Minutes { get; set; }
	internal int Seconds { get; set; }

	public Song(string name, int length, int placement)
	{
		this.Name = name;
		this.Length = length;
		this.Placement = placement;
		this.Minutes = Length / 60;
		this.Seconds = Length - (Minutes * 60);
	}
	public override string ToString()
	{
		return $"{this.Placement} - {this.Name} ({this.Minutes}:{(this.Seconds<10?$"0":"")}{this.Seconds})";
	}
}
