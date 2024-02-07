using System.Collections;
using System.Collections.Generic;

public class Nicknames
{
	public string Brand { get; set; }
	public ICollection<string> Nickname { get; set; }

	public Nicknames() { }
	public Nicknames(string brand, ICollection<string> nick)
	{
		this.Brand = brand;
		this.Nickname = nick;
	}

	public override string ToString()
	{
		return $"Motor márkája: {Brand} - Nick: {Nickname}";
	}
}