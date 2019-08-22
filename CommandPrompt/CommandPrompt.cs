using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
	class CommandPrompt
	{
		//unknownType backgroundColor;
		//unknownType foregroundColor;

		string[] screenText;
		int height;
		int columns;
		ConsoleColor backgroundColor;
		ConsoleColor foregroundColor;


		public CommandPrompt(int height, int columns)
		{
			// set the backgroundColor to some default
			backgroundColor = ConsoleColor.White;


			// set the foregroundColor to some default
			foregroundColor = ConsoleColor.Blue;


			// create the screen to hold the number of rows passed in with the height parameter
			screenText = new string[height];


			// we will use the C# object to set the size of our window.
			Console.SetWindowSize(columns, height + 7);


			// let's set the initial screen rows to all blank lines
			for (int i = 0; i < screenText.Length; i++)
			{
				screenText[i] = "";
			}
		}// end of CommandPrompt constructor

		public void Display()
		{

			// set the foreground and background colors
			Console.BackgroundColor = backgroundColor;
			Console.ForegroundColor = foregroundColor;


			Console.Clear();             // The Console object is available to us to control aspects of our terminal window. 
										 // The Clear method will blank our window.
										 // The Clear method has blanked the screen and left the cursor at the top of the window.
										 // We will now loop through the screenText array to put out text on the screen.

			for (int i = 0; i < screenText.Length; i++)
			{
				Console.WriteLine(screenText[i]);
			}
		}   // end of Display method

		public void SetScreenText(int lineNumber, string lineOfText)
		{
			screenText[lineNumber] = lineOfText;
		}
		// end of SetScreenText method

		public void SetBackgroundColor(string color)
		{
			backgroundColor = ConvertColor(color);
		}

		public void SetForegroundColor(string color)
		{
			foregroundColor = ConvertColor(color);
		}

		public static ConsoleColor ConvertColor(string strColor)
		{
			ConsoleColor color;
			switch (strColor.ToLower())
			{
				case "black": color = ConsoleColor.Black; break;
				case "red": color = ConsoleColor.Red; break;
				case "yellow": color = ConsoleColor.Yellow; break;
				case "blue": color = ConsoleColor.Blue; break;
				case "green": color = ConsoleColor.Green; break;

				default: color = ConsoleColor.DarkGray; break;
			}

			return color;

		}

		public void ClearScreen()
		{
			for (int i = 0; i < screenText.Length; i++)
			{
				screenText[i] = "";
			}
		}
	}
}



