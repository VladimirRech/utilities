using System;
using System.Linq;

public class program {
	const string _error = "Usage: fmtnum number format";
	const string _help = "\n\tNumber: numeric chars to format\n\tFormat: ex: ###.###.###-##";
	static string[] _help_sign = new string[] { "--help", "-h", "--h", "-?", "/?", "/h", "/help" };

	public static void Main(string[] args){
		if (args.Length != 2) {
			Console.WriteLine(_error);

		 	if (args.Length == 1 && _help_sign.Contains(args[0]))
				Console.WriteLine(_help);

			return;
		}
	}
}
