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

		Console.WriteLine(FormatWithMask(args[0], args[1]));
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
