using System;
using System.Collections.Generic;
using System.Globalization;

namespace SportsScores
{
    class Program
    {

        static private List<ClassScore> scores = new List<ClassScore>();

        private static void DisplayScores()
        {
            Console.Clear();
            scores = DataUtilityClass.GetScores();
            if (scores != null)
            {
                if (scores.Count == 0)
                {
                    Console.WriteLine("\n\t\tThere are no scores to display yet. Please add some.");
                }
                else
                {
                    Console.WriteLine("\t\tScores\n");
                    Console.Write("\t\tEntry #".PadRight(30));
                    Console.Write("Date".PadRight(30));
                    Console.WriteLine("Score");
                    for (int i = 0; i < scores.Count; i++)
                    {
                        Console.Write("\t\t"+(i+1).ToString().PadRight(28));
                        Console.Write(scores[i].ScoreDate.ToString().PadRight(30));
                        Console.WriteLine(scores[i].Score.ToString());
                    }
                    Console.WriteLine("\n\n");
                }
            }
        }

        private static void AddScore()
        {
            String input;
            Boolean valid = false;
            DateTime sDate;
            int sVal;
            do
            {
                Console.Clear();
                Console.Write("\n\t\tPlease enter a valid date for the game: ");
                input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sDate))
                    valid = true;
                else
                {
                    Console.WriteLine("\n\t\tThat was not a valid date, (like 01/01/1970) please try again!!!");
                    Console.Write("\n\t\tPress any key...");
                    Console.ReadKey();
                }
            } while (valid == false);
            do
            {
                Console.Clear();
                Console.Write("\n\t\tPlease enter a whole number score for the game: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out sVal))
                    valid = true;
                else
                {
                    Console.WriteLine("\n\t\tThat was not a valid whole number, please try again!!!");
                    Console.Write("\n\t\tPress any key...");
                    Console.ReadKey();
                }
            } while (valid == false);
            DataUtilityClass.AddScore(new ClassScore(sDate.Date.ToString("d"), sVal));
        }

        static void Main(string[] args)
        {
            String input;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\tMenu");
                Console.WriteLine("\n\t\tA. Add a Score");
                Console.WriteLine("\n\t\tD. Display all Scores");
                Console.WriteLine("\n\t\tQ. Quit application");
                Console.Write("\n\tEnter a selection and press enter: ");
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "A":
                        AddScore();
                        break;
                    case "D":
                        DisplayScores();
                        break;
                    case "Q":
                        Console.Clear();
                        Console.Write("\n\t\tGoodbye!!!.");
                        break;
                    default:
                        Console.WriteLine("\n\t\tThat is not a valid input.");
                        break;
                }
                Console.Write("\n\n\tPress any key to continue...");
                Console.ReadKey();
            } while (input.ToLower() != "q");
            DataUtilityClass.CloseDBConn();
        }
    }
}
