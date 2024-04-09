using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Library.SystemExtensions;

public static class ExtendedSystem
{
    public static void WriteToConsole(this object objectToDisplay) => Console.Write(objectToDisplay);
	
	public static void WriteCollectionToConsole<T>(this ICollection<T> collectionToDisplay) where T : class
	{
		foreach (T item in collectionToDisplay)
		{
			Console.WriteLine(item);
		}
	}
}
