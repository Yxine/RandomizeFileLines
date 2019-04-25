﻿using System;
using f = System.IO.File;
using a = System.Reflection.Assembly;
using c = System.Console;
using e = System.Environment;

// ReSharper disable once CheckNamespace
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
			c.Write($"{e.NewLine} *{e.NewLine} * Randomize File Lines version {a.GetEntryAssembly().GetName().Version}{e.NewLine} * https://computerraru.ru/software/rfl{e.NewLine} * Larin Alexsandr{e.NewLine} *{e.NewLine}");
			c.ForegroundColor = ConsoleColor.White;
			if (!args.Length.Equals(1))
			{
				c.WriteLine($"{e.NewLine}   Ошибочка...{e.NewLine}   Укажите первым параметром имя файла, например:{e.NewLine}{e.NewLine}   CMD> RandomizeFileLines.exe worktodo.txt{e.NewLine}");
				c.ForegroundColor = ConsoleColor.Gray;
				c.WriteLine("   Press a key to exit...");
				c.ReadKey();
				return;
			}
			if (args.Length == 0) return;
			var file = args[0];
			if (!f.Exists(file)) return;
			var s = f.ReadAllLines(file);
			Array.Sort(s, StringComparer.InvariantCulture);
			f.WriteAllLines(file, s);
		}

	}

}
