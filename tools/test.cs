using System;

public class Class {
	public static void Main() {
		int val = MyMethod();
		Console.WriteLine("Valor retornado: {0}", val);
	}
	
	public static int MyMethod() {
		var ret = 1;
		try {
			Console.WriteLine("Dentro do try...");
			return 1;
		}
		catch {
			Console.WriteLine("Nunca será...");
		}
		finally {
			Console.WriteLine("Finally");
			ret = -1;
		}
		
		return ret;
	}
}