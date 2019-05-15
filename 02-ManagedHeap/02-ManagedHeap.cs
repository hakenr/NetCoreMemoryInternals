using System;
using System.Diagnostics;

namespace Haken.ManagedHeap
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const int count = 20;

			for (int i = 0; i < count; i++)
			{
				MyClass newInstance = new MyClass();
			}

			Debugger.Break();
		}
	}

	public class MyClass
	{
		private byte[] pole = new byte[1024];
	}
}
