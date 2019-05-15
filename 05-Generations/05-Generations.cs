using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.Generations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string localStringVariable1 = "první string";

			// Gen0
			Console.WriteLine("localStringVariable1 Generation: " + GC.GetGeneration(localStringVariable1));
			Debugger.Break();

			GC.Collect();

			// Gen1
			Console.WriteLine("localStringVariable1 Generation: " + GC.GetGeneration(localStringVariable1));
			Debugger.Break();

			GC.Collect();

			// Gen2
			Console.WriteLine("localStringVariable1 Generation: " + GC.GetGeneration(localStringVariable1));
			Debugger.Break();

		}
	}
}
