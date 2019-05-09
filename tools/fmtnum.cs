using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

//
// Format numbers aplying or removing a specified mask
// 08/05/2019
// Vladimir Rech
//
public class program {
	const string _error = "Usage: fmtnum number format";
	const string _help = "\n\tNumber: numeric chars to format\n\tFormat: ex: ###.###.###-##" + 
						 "\n\t\tto remove mask use '#' char as second argument.";
	const string _maskChar = "#";
	const string _regexMask = "[^0-9]";

	static string[] _help_sign = new string[] { "--help", "-h", "--h", "-?", "/?", "/h", "/help" };

	public static void Main(string[] args){
		if (args.Length != 2) {
			Console.WriteLine(_error);

		 	if (args.Length == 1 && _help_sign.Contains(args[0]))
				Console.WriteLine(_help);

			return;
		}

		string ret = args[1] == _maskChar ? RemoveMask(args[0]) : 
								FormatWithMask(args[0], args[1]);
		Console.WriteLine(ret);
	}

	//
	// Remove mask form a specified text
	// 
	static string RemoveMask(string input){
		StringBuilder sb = new StringBuilder();		
		
		if (String.IsNullOrEmpty(input)) return input;		
		
		var regex = new Regex(_regexMask);
		return regex.Replace(input, "");
	}


	/// <summary>
	/// Formats the string according to the specified mask. 
	/// Source: http://www.extensionmethod.net/1981/csharp/string/formatwithmask
	/// </summary>
	/// <param name="input">The input string.</param>
	/// <param name="mask">The mask for formatting. Like "A##-##-T-###Z"</param>
	/// <returns>The formatted string</returns>
	static string FormatWithMask(string input, string mask)
	{
		if (String.IsNullOrEmpty(input)) 
		return input;

		var output = string.Empty;
		var index = 0;

		foreach (var m in mask)
		{
			if (m == '#')
			{
				if (index < input.Length)
				{
					output += input[index];
					index++;
				}
			}
			else
				output += m;
		}
		return output;
	}
}
