using System;
using System.Collections.Generic;

namespace GradeTracker
{
	class Program
	{
		private static List<StudentGrade> grades = new List<StudentGrade>();

		static void Main(string[] args)
		{
			Console.Title = "📘 Student Grade Tracker";
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\n=== GRADE TRACKER MENU ===");
				Console.ResetColor();

				Console.WriteLine("1) Add New Grade");
				Console.WriteLine("2) List All Grades");
				Console.WriteLine("3) Calculate Average");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice: ");
				string choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						AddGrade();
						break;
					case "2":
						ListGrades();
						break;
					case "3":
						CalculateAverage();
						break;
					case "0":
						Console.WriteLine("Exiting...");
						return;
					default:
						ShowError("Invalid choice!");
						break;
				}
			}
		}

		private static void AddGrade()
		{
			Console.Write("Student Name: ");
			string name = Console.ReadLine().Trim();

			Console.Write("Course Name: ");
			string course = Console.ReadLine().Trim();

			Console.Write("Grade (0-100): ");
			int score;
			bool valid = int.TryParse(Console.ReadLine(), out score);

			if (!valid || score < 0 || score > 100)
			{
				ShowError("Please enter a valid grade between 0 and 100.");
				return;
			}

			grades.Add(new StudentGrade
			{
				StudentName = name,
				Course = course,
				Grade = score
			});

			ShowSuccess("✅ Grade added successfully!");
		}

		private static void ListGrades()
		{
			if (grades.Count == 0)
			{
				Console.WriteLine("📭 No grades added yet.");
				return;
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Student\t\tCourse\t\tGrade");
			Console.ResetColor();

			foreach (StudentGrade g in grades)
			{
				Console.WriteLine("{0}\t\t{1}\t\t{2}", g.StudentName, g.Course, g.Grade);
			}
		}

		private static void CalculateAverage()
		{
			if (grades.Count == 0)
			{
				ShowError("No grades to calculate.");
				return;
			}

			double total = 0;
			foreach (StudentGrade g in grades)
				total += g.Grade;

			double average = total / grades.Count;

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("📊 Average Grade: {0:F2}", average);
			Console.ResetColor();

			if (average >= 60)
				ShowSuccess("👏 Passed!");
			else
				ShowError("😢 Failed the class.");
		}

		private static void ShowError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("❌ " + message);
			Console.ResetColor();
		}

		private static void ShowSuccess(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}

	class StudentGrade
	{
		public string StudentName { get; set; }
		public string Course { get; set; }
		public int Grade { get; set; }
	}
}
