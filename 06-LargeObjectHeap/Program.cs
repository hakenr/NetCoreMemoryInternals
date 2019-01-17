using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.LargeObjectHeap
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//GC.TryStartNoGCRegion(500_000);
			//GC.EndNoGCRegion();

			byte[] empty = new byte[0]; // 24 bytes
			byte[] soh = new byte[85000 - 25];
			byte[] loh = new byte[85000 - 24];

			Console.WriteLine($"soh Generation: " + GC.GetGeneration(soh));
			Console.WriteLine($"loh Generation: " + GC.GetGeneration(loh));
			Debugger.Break();

			soh = null;
			loh = null;
			GC.Collect(); // rooted by CPU regs
			Debugger.Break();
		}
	}
}
 