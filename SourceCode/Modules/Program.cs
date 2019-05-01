using System;
using b = System.Diagnostics.Stopwatch;
using a = System.Reflection.Assembly;
using c = System.Console;
using e = System.Environment;
using f = System.IO.File;
using w = System.Threading.Thread;

namespace RandomizeFileLines
{

	/// <summary>Program main class</summary>
	internal class Program
	{

		/// <summary>Entry point</summary>
		/// <param name="args">Command-line arguments</param>
		private static void Main(string[] args)
		{
			var n = e.NewLine;
			c.Clear();
			c.Title = "Randomize File Lines";
			c.CursorVisible = false;
			c.ForegroundColor = ConsoleColor.DarkGreen;
			c.SetCursorPosition(0, 0);
			c.Write("************************************************************************************************************************");
			c.SetCursorPosition(0, 6);
			c.Write("------------------------------------------------------------------------------------------------------------------------");
			c.SetCursorPosition(3, 2);
			c.ForegroundColor = ConsoleColor.White;
			c.Write("Randomize File Lines version {0}{1}   https://larin.name/software/randomize-file-lines{1}   Larin Alexsandr", a.GetEntryAssembly()?.GetName().Version, n);
			c.ForegroundColor = ConsoleColor.Gray;
			c.SetCursorPosition(3, 8);
			if (!args.Length.Equals(1))
			{
				c.WriteLine("Error...{0}   Specify the file name as the first parameter, for example:{0}{0}   CMD> RandomizeFileLines.exe worktodo.txt{0}", n);
				c.ForegroundColor = ConsoleColor.DarkGray;
				c.Write("   Press a key to exit...");
				c.ReadKey();
				return;
			}
			if (args.Length == 0) return;
			var t = new b();
			t.Start();
			var file = args[0];
			if (!f.Exists(file)) return;
			var s = f.ReadAllLines(file);
			c.WriteLine("Processing {0} lines...", s.Length);
			Array.Sort(s, StringComparer.InvariantCulture);
			f.WriteAllLines(file, s);
			t.Stop();
			c.Write("   Done for {0} seconds!", t.Elapsed);
			w.Sleep(3000);
		}

	}

}
