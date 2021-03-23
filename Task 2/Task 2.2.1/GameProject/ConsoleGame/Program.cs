using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;

namespace ConsoleGame
{
    class Program
    {
        static int Height = 20;

        static void Main(string[] args)
        {
            int width = 20;
            int height = 20;

            Console.WindowLeft = 0;
            Console.WindowWidth = 25;
            Console.WindowTop = 0;
            Console.WindowHeight = 25;
            Console.SetBufferSize(25, 25);
            Game game = new Game(width, height);
            game.GameUpdated += new GameUpdatedHandler(VisualiseFrame);
            game.Start();

            Console.ReadLine();
        }

        public static void VisualiseFrame(object game, EventArgs args)
        {
            Console.Clear();
            var game_field = (game as Game).Field.Container;
            foreach (var game_obj in game_field)
            {
                if (game_obj is Player) RenderObject(game_obj.Position, '&');
                else if (game_obj is Enemy) RenderObject(game_obj.Position, '*');
                else if (game_obj is Obstacle) RenderObject(game_obj.Position, '/');
                else if (game_obj is Bonus) RenderObject(game_obj.Position, '+');
            }
        }

        public static Point ConvertToConsolePoint(Point value, int maxHeight) => new Point(value.X, maxHeight - value.Y);

        public static void RenderObject(Point position, char symbol)
        {
            Point console_point = ConvertToConsolePoint(position, 20);
            Console.SetCursorPosition(console_point.X, console_point.Y);
            Console.Write(symbol);
        }
    }
}
