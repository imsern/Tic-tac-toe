using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Tre_på_rad.BoardView;

namespace Tre_på_rad
{
    public class BoardModel
    {
        private readonly Random random = new();
        public List<string> Values = new();
        public bool isRunning = true;

        public BoardModel()
        {
            InitList();
        }

        private void InitList()
        {
            for (int i = 0; i < 9; i++)
            {
                Values.Add(" ");
            }
        }


        public async Task SetCross(string? value)
        {
            switch (value)
            {
                case "a1" when Values[0] == " ":
                    Values[0] = "x";
                    break;
                case "b1" when Values[1] == " ":
                    Values[1] = "x";
                    break;
                case "c1" when Values[2] == " ":
                    Values[2] = "x";
                    break;
                case "a2" when Values[3] == " ":
                    Values[3] = "x";
                    break;
                case "b2" when Values[4] == " ":
                    Values[4] = "x";
                    break;
                case "c2" when Values[5] == " ":
                    Values[5] = "x";
                    break;
                case "a3" when Values[6] == " ":
                    Values[6] = "x";
                    break;
                case "b3" when Values[7] == " ":
                    Values[7] = "x";
                    break;
                case "c3" when Values[8] == " ":
                    Values[8] = "x";
                    break;
                default:
                    Console.WriteLine("Unknown value or Invalid option!");
                    break;
            }
            Console.Clear();
            Show(Values);

            if (!CheckIfWon()) return;
            Console.WriteLine("Vil du starte på nytt? (y/n)");
            var restart = Console.ReadLine();
            switch (restart)
            {
                case "y":
                    {
                        Values.Clear();
                        Console.Clear();
                        await Start();
                        break;
                    }
                case "n":
                    Environment.Exit(0);
                    break;
            }
        }

        public async Task SetCircle()
        {
            while (true)
            {
                var randomIndex = random.Next(0, 9);
                if (Values[randomIndex] == " ")
                {
                    Values[randomIndex] = "o";
                }
                else
                    continue;

                break;
            }

            Console.Clear();
            Show(Values);

            if (!CheckIfWon()) return;
            Console.WriteLine("Vil du starte på nytt? (y/n)");
            var restart = Console.ReadLine();
            switch (restart)
            {
                case "y":
                    {
                        Values.Clear();
                        Console.Clear();
                        await Start();
                        break;
                    }
                case "n":
                    Environment.Exit(0);
                    break;
            }
        }

        public bool CheckIfWon()
        {
            if ((Values[0] == "x" && Values[1] == "x" && Values[2] == "x") ||
                (Values[3] == "x" && Values[4] == "x" && Values[5] == "x") ||
                (Values[6] == "x" && Values[7] == "x" && Values[8] == "x") ||
                (Values[0] == "x" && Values[3] == "x" && Values[6] == "x") ||
                (Values[1] == "x" && Values[4] == "x" && Values[7] == "x") ||
                (Values[2] == "x" && Values[5] == "x" && Values[8] == "x") ||
                (Values[0] == "x" && Values[4] == "x" && Values[8] == "x") ||
                (Values[6] == "x" && Values[4] == "x" && Values[2] == "x"))
            {
                isRunning = false;
                Console.WriteLine("Player won!");
                return true;
            }
            if ((Values[0] == "o" && Values[1] == "o" && Values[2] == "o") ||
                (Values[3] == "o" && Values[4] == "o" && Values[5] == "o") ||
                (Values[6] == "o" && Values[7] == "o" && Values[8] == "o") ||
                (Values[0] == "o" && Values[3] == "o" && Values[6] == "o") ||
                (Values[1] == "o" && Values[4] == "o" && Values[7] == "o") ||
                (Values[2] == "o" && Values[5] == "o" && Values[8] == "o") ||
                (Values[0] == "o" && Values[4] == "o" && Values[8] == "o") ||
                (Values[6] == "o" && Values[4] == "o" && Values[2] == "o"))
            {
                isRunning = false;
                Console.WriteLine("AI won!");
                return true;
            }

            return false;
        }
    }
}
