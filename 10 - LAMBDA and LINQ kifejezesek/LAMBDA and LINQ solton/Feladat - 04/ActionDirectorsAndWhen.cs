using System;
using System.Collections.Generic;
using System.Text;

public class ActionDirectorsAndWhen
{
	public string name { get; set; }
	public List<DateTime> times { get; set;}

	public ActionDirectorsAndWhen () { }

	public ActionDirectorsAndWhen(string name, List<DateTime> times)
	{
		this.name = name;
		this.times = times;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(name);
		foreach(var date in times)
		{
			sb.AppendLine($"\t-{date:yyyy-mm-dd}");
		}
		return sb.ToString();
	}
}