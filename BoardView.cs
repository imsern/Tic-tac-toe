using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tre_på_rad
{
    public class BoardView 
    {

        static BoardModel model = new BoardModel();

        public static async Task Start()
        {
            var model = new BoardModel();
            BoardView.Show();
            while (model.isRunning)
            {

                Console.WriteLine("Skriv inn hvor du vil sette kryss (f.eks \"a2\") ");
                var x = Console.ReadLine();
                await model.SetCross(x);
                await Task.Delay(2000);
                await model.SetCircle();
            }
        }
        public static void Show()
        {
            Console.WriteLine("  a b c ");
            Console.WriteLine(" ┌─────┐");
            Console.WriteLine("1│     │");
            Console.WriteLine("2│     │");
            Console.WriteLine("3│     |");
            Console.WriteLine(" └─────┘");
        }
        public static void Show(List<string> value)
        {
            Console.WriteLine("  a b c ");
            Console.WriteLine(" ┌─────┐");
            Console.WriteLine(
                $"1│{(value[0] == null ? " " : value[0])} {(value[1] == null ? " " : value[1])} {(value[2] == null ? " " : value[2])}│");
            Console.WriteLine(
                $"2│{(value[3] == null ? " " : value[3])} {(value[4] == null ? " " : value[4])} {(value[5] == null ? " " : value[5])}│");
            Console.WriteLine(
                $"3│{(value[6] == null ? " " : value[6])} {(value[7] == null ? " " : value[7])} {(value[8] == null ? " " : value[8])}│");
            Console.WriteLine(" └─────┘");
        }
    }
}
