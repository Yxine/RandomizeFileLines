using System;
using System.Linq;
using System.IO;
using System.Reflection;
using c = System.Console;

namespace RandomizeFileLines
{

	/// <summary>Класс программы</summary>
	internal class Program
	{

		/// <summary>Точка входа</summary>
		/// <param name="args">Аргументы командной строки</param>
		private static void Main(string[] args)
		{
			c.Clear();
			c.Title = "Randomize File Lines";
			c.CursorVisible = false;
			c.WriteLine();
			c.WriteLine(" *");
			c.WriteLine($" * Randomize File Lines version {Assembly.GetEntryAssembly().GetName().Version}");
			c.WriteLine(" * http://computerraru.ru/software/rfl");
			c.WriteLine(" * Larin Alexsandr");
			c.WriteLine(" *");
			c.WriteLine();
			c.ForegroundColor = ConsoleColor.White;
			if (!args.Length.Equals(1))
			{
				c.WriteLine("   Ошибочка...");
				c.WriteLine("   Укажите первым параметром имя файла, например:");
				c.WriteLine();
				c.WriteLine("   > RandomizeFileLines.exe worktodo.txt");
				c.WriteLine();
				c.ForegroundColor = ConsoleColor.Gray;
				c.WriteLine("   Press a key to exit...");
				c.ReadKey();
				return;
			}
			if (args.Length.Equals(0)) return;
			var file = args[0];
			if (!File.Exists(file)) return;
			// must be here, outside the expression!
			var r = new Random();
			File.WriteAllLines(file, File.ReadAllLines(file).OrderBy(x => r.Next()).ToArray());
		}

	}

}
