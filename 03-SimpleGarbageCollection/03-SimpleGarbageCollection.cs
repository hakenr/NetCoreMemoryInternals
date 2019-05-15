using System;
using System.Diagnostics;

namespace Haken.SimpleGarbageCollection
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const int count = 1000;

			MyClass firstInstance;
			MyClass lastInstance;

			for (int i = 0; i < count; i++)
			{
				MyClass newInstance = new MyClass();

				if (i == 0)
				{
					firstInstance = newInstance;
				}
				else if (i == count - 1)
				{
					lastInstance = newInstance;
				}
			}

			Debugger.Break();

			GC.Collect();

			Debugger.Break();
		}
	}

	public class MyClass
	{
		private byte[] pole = new byte[1024];
	}
}
