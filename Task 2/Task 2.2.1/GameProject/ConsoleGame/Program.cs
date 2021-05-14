namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GameLib;

    internal static class Program
    {
        // Entry point
        private static void Main()
        {
            InitializeConsole();
            InitializeGame();
            DrawBorder();
            
            game.Start();

            ConsoleKey pressedKey = default;
            while (pressedKey != ConsoleKey.Escape && !Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                pressedKey = key.Key;
                switch (pressedKey)
                {
                    default: 
                        break;
                    case ConsoleKey.Escape: 
                        return;
                    case ConsoleKey.Spacebar: 
                        Console.WriteLine((int)key.KeyChar); 
                        break;
                    case ConsoleKey.W: 
                        game.Player.CurrentDirection = Direction.Up; 
                        break;
                    case ConsoleKey.A: 
                        game.Player.CurrentDirection = Direction.Left; 
                        break;
                    case ConsoleKey.S: 
                        game.Player.CurrentDirection = Direction.Down; 
                        break;
                    case ConsoleKey.D: 
                        game.Player.CurrentDirection = Direction.Right;
                        break;
                }
            }
        }

        // Fields
        private static int height = 20;

        private static int width = 20;

        private static List<Point> lastPositions;

        private static List<GameObject> gameObjects;

        private static Game game;

        // Methods
        public static void VisualiseFrame(object game, EventArgs args)
        {
            foreach (var position in lastPositions)
            {
                DrawChar(position, ' ');
            }

            lastPositions.Clear();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Player)
                {
                    DrawChar(gameObject.Position, '&');
                }
                else if (gameObject is Enemy)
                {
                    DrawChar(gameObject.Position, '*');
                }
                else if (gameObject is Obstacle)
                {
                    DrawChar(gameObject.Position, '/');
                }
                else if (gameObject is Bonus)
                {
                    DrawChar(gameObject.Position, '+');
                }

                if (gameObject is IMovable)
                {
                    lastPositions.Add(gameObject.Position);
                }
            }
        }

        public static void InitializeConsole()
        {
            Console.Title = "Console Game";
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;

            int windowWidth = width + 5;
            int windowHeight = height + 5;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);
        }

        public static void InitializeGame()
        {
            lastPositions = new List<Point>();
            game = new Game(width, height);
            game.Reset();
            gameObjects = game.Field.Container;
            game.GameUpdated += new GameUpdatedHandler(VisualiseFrame);
        }

        public static void DrawBorder()
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, width);
                Console.Write('═');
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(height, i);
                Console.Write('║');
            }

            Console.SetCursorPosition(width, height);
            Console.Write('╝');
        }

        public static Point ToConsolePoint(Point value, int maxHeight) => new Point(value.X, maxHeight - value.Y - 1);

        public static void DrawChar(Point position, char symbol)
        {
            Point consolePoint = ToConsolePoint(position, height);
            Console.SetCursorPosition(consolePoint.X, consolePoint.Y);
            Console.Write(symbol);
        }
    }
}