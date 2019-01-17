using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.MissingDispose
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Test();
			GC.Collect();

			Debugger.Break();

			GC.WaitForPendingFinalizers();

			Debugger.Break();

			GC.Collect();

			Debugger.Break();
		}

		private static void Test() // xbp register clearance
		{
			var bitmap1 = new Bitmap(4096, 4096);
			var bitmap2 = new Bitmap(4096, 4096);
			var bitmap3 = new Bitmap(4096, 4096);

			//bitmap1.Dispose();
			//bitmap2.Dispose();
			//bitmap3.Dispose();

			bitmap1 = null;
			bitmap2 = null;
			bitmap3 = null;
		}
	}
}
