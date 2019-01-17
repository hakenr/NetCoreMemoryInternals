using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.UnmanagedResources
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start aplikace.\nAktuální spotřeba {0:n0} kB (managed {1:n0} kB).\n", Process.GetCurrentProcess().WorkingSet64 / 1024, GC.GetTotalMemory(false) / 1024);
			Console.ReadKey();

			var bitmap = new Bitmap(4096, 4096);

			Console.WriteLine("new Bitmap(4096,4096);\nAktuální spotřeba {0:n0} kB (managed {1:n0} kB).\n", Process.GetCurrentProcess().WorkingSet64 / 1024, GC.GetTotalMemory(false) / 1024);
			Console.ReadKey();

			//bitmap.Dispose();  // správně using (..) { ... }

			Console.WriteLine("bitmap.Dispose();\nAktuální spotřeba {0:n0} kB (managed {1:n0} kB).\n", Process.GetCurrentProcess().WorkingSet64 / 1024, GC.GetTotalMemory(false) / 1024);
			Console.ReadKey();

			bitmap = null;
			GC.Collect();

			Console.WriteLine("bitmap = null; GC.Collect();\nAktuální spotřeba {0:n0} kB (managed {1:n0} kB).\n", Process.GetCurrentProcess().WorkingSet64 / 1024, GC.GetTotalMemory(false) / 1024);
			Console.ReadKey();

			//GC.WaitForPendingFinalizers();
			//GC.Collect();

			//Console.WriteLine("bitmap = null; GC.WaitForPendingFinalizers(); GC.Collect();\nAktuální spotřeba {0:n0} kB (managed {1:n0} kB).", Process.GetCurrentProcess().WorkingSet64 / 1024, GC.GetTotalMemory(false) / 1024);
			//Console.ReadKey();
		}
	}
}
