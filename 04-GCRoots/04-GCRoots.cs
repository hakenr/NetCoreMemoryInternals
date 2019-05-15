using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.GCRoots
{
	public class Program
	{
		private static MyClass staticField;

		public static void Main(string[] args)
		{
			MyClass localVariable = new MyClass(1, "první instance do localVariable - opustí se");

			staticField = new MyClass(2, "instance do staticField");
			staticField.OtherReference = new MyClass(3, "instance do staticField.OtherReference");

			localVariable = new MyClass(4, "druhá instance do localVariable");

			Debugger.Break();

			localVariable = null;

			Debugger.Break(); // KVÍZ: Viz roots poslední instance, čím je způsobeno?
		}
	}

	public class MyClass
	{
		public static MyClass LastInstance;

		public object OtherReference;

		public int _id;
		public string _name;

		public MyClass(int id, string name)
		{
			_id = id;
			_name = name;
			OtherReference = new object();
			LastInstance = this;
		}
	}
}