using System.Collections;
using System.Collections.Generic;

public class GamesByDeveloper
{
	public string Developer {  get; set; }
	public ICollection<string> Games { get; set; }

	public GamesByDeveloper() { }
	public GamesByDeveloper(string developer,  ICollection<string> games)
	{
		this.Developer = developer; 
		this.Games = games;
	}
}