using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLibrary;

public static class SystemExtensions
{
	public static void WriteToConsole(this object number)
	{
        Console.Write(number);
    }
}
