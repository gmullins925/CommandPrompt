using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
	class Program
	{
		static void Main(string[] args)
		{
			CommandPrompt myCommand = new CommandPrompt(10, 15);
			myCommand.SetScreenText(2, "This line 2 text");
			myCommand.SetScreenText(1, "This is line 2 text");
			myCommand.SetScreenText(4, "At line 4");
			myCommand.SetScreenText(11, "Line 11 looks like this");
			myCommand.Display();
			Console.ReadLine();
		}
	}
}
