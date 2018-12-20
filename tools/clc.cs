using System;

//
// clc : prompt calculation
//
public class clc {
	public static void Main(string[] args) {
		if (args.Length != 3) {
			Console.WriteLine("Usage: clc number1 operator number2");
			return;
		}
		
		double n1 = 0d;
		double n2 = 0d;
		double result = 0d;
		
		if (!double.TryParse(args[0], out n1) || !double.TryParse(args[2], out n2)) {
			Console.WriteLine("Arguments are invalid.");
			return;
		}
		
		if (args[1] == "/" && n2 == 0) {
			Console.WriteLine("There isn't division by 0.");
			return;
		}
		
		switch(args[1].ToLower()) {
			case "+": result = n1 + n2; break;
			case "-": result = n1 - n2; break;
			case "*":
			case "x":
				result = n1 * n2; break;
			case "/":
				result = n1 / n2; break;
			case "pow": result = Math.Pow(n1, n2); break;
			case "%": result = n1 % n2; break;
			case "sqr": result = n2 == 2 ? Math.Sqrt(n1) : Math.Pow(n1, 1 / n2); break;
			default:
				Console.WriteLine("Valid operators are: '+', '-', '*', 'x', 'X', '*', 'pow', '%', 'sqr'");
				break;
		}
		
		Console.WriteLine("Result: {0}", result);
	}
}