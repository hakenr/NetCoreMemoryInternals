using System;
using System.Diagnostics;

namespace Haken.StackHeap
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// lokální proměnné
			int a = 0xAAAA;
			bool b = true;
			Int64 c = 0xCCCCCCCC;
			for (int i = 0; i < 0xFF; i++)
			{
				MyClass instance = new MyClass(a); // instance třídy -> heap
			}
			int r;

			// volání metody
			Debugger.Break();
			r = DoSomething(a, null);
			Debugger.Break();

			Console.ReadLine();
		}

		private static int DoSomething(int vstupniParametr, string druhyParametr)
		{
			// lokální proměnné
			int d = 0xDDDD;
			int e = 0xEEEE;

			// volání dalších metod
			Debugger.Break();
			DoSomethingElse();
			Debugger.Break();
			DoNothing();
			Debugger.Break();

			return vstupniParametr + 1;
		}

		private static void DoSomethingElse()
		{
			Debugger.Break();
		}

		private static void DoNothing()
		{
			Debugger.Break();
		}
	}

	public class MyClass
	{
		private int _field;
		private int _field2;
		private int _field3;

		public MyClass(int field)
		{
			_field = field;
		}
	}
}