using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace RandomizeFileLines
{

	/// <summary>Класс программы</summary>
	internal class Program
	{

		/// <summary>Точка входа</summary>
		/// <param name="args">Аргументы командной строки</param>
		private static void Main(string[] args)
		{
			Console.Clear();
			Console.Title = "Randomize File Lines";
			Console.CursorVisible = false;
			Console.WriteLine();
			Console.WriteLine(" *");
			Console.WriteLine($" * Randomize File Lines version {Assembly.GetEntryAssembly().GetName().Version}");
			Console.WriteLine(" * http://computerraru.ru/software/rfl");
			Console.WriteLine(" * Larin Alexsandr");
			Console.WriteLine(" *");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.White;
			if (!args.Length.Equals(1))
			{
				Console.WriteLine("   Ошибочка...");
				Console.WriteLine("   Укажите первым параметром имя файла, например:");
				Console.WriteLine();
				Console.WriteLine("   > RandomizeFileLines.exe worktodo.txt");
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine("   Press a key to exit...");
				Console.ReadKey();
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
