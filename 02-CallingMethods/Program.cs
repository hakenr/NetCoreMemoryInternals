using System.Diagnostics;

namespace Haken.CallingMethods
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// inicializace
			int valueTypeVariable1 = 0xAAAA;

			MyClass referenceTypeVariable1 = new MyClass();
			referenceTypeVariable1.ValueProperty = 1111;
			referenceTypeVariable1.ReferenceProperty = null;

			Debugger.Break();

			// předání parametrů "hodnotou" (ByVal)
			MyMethod(valueTypeVariable1, referenceTypeVariable1);

			Debugger.Break();

			// předání parametrů "odkazem" (ByRef)
			MyMethodWithByRefParameters(ref valueTypeVariable1, ref referenceTypeVariable1);

			Debugger.Break();
		}

		private static int MyMethod(
			int valueTypeParameter,
			MyClass referenceTypeParameter)
		{
			Debugger.Break();

			valueTypeParameter++;
			referenceTypeParameter.ValueProperty++;

			Debugger.Break();

			referenceTypeParameter = new MyClass();
			referenceTypeParameter.ValueProperty = 2222;

			Debugger.Break();

			return valueTypeParameter;
		}

		private static void MyMethodWithByRefParameters(
			ref int valueTypeParameter,
			ref MyClass referenceTypeParameter)
		{
			Debugger.Break();

			valueTypeParameter++;
			referenceTypeParameter.ValueProperty++;

			Debugger.Break();

			referenceTypeParameter = new MyClass();
			referenceTypeParameter.ValueProperty = 2222;

			Debugger.Break();
		}
	}

	public class MyClass
	{
		public int ValueProperty { get; set; }

		public MyClass ReferenceProperty { get; set; }
	}

	public struct Coordinates
	{
		public int X { get; set; }

		public int Y { get; set; }
	}
}