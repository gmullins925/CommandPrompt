using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
				case "white": color = ConsoleColor.White; break;
				case "magenta": color = ConsoleColor.Magenta; break;

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

		public void SaveScreen(string fileName)
		{
			FileStream stream;
			StreamWriter textOut = null;

			try
			{
				fileName = "C:/Users/ACT/Desktop/CSharpPrgmSave/" + fileName;
				stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
				textOut = new StreamWriter(stream);

				textOut.WriteLine("Testing, Testing 1,2,3");

			}
			catch (Exception)
			{
				Console.WriteLine("Error");
			}

			finally
			{
				if (textOut != null)
					textOut.Close();
			}
		}
		public void ReloadScreen(string filenameRead)
		{
			FileStream stream;
			StreamReader textIn = null;

			try
			{
				filenameRead = "C:/Users/ACT/Desktop/CSharpPrgmSave/" + filenameRead;
				stream = new FileStream(filenameRead, FileMode.Open, FileAccess.Read);
				textIn = new StreamReader(stream);

				for (int i = 0; i < screenText.Length; i++)
				{
					Console.WriteLine(textIn.ReadLine());
				}

				
				Console.ReadLine();

			}
			catch (Exception e)
			{
				// Let the user know what went wrong.
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}


			}
	}
}



