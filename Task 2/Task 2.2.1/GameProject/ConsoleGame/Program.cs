namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GameLib;
    
    class Program
    {
        static void Main()
        {
            InitializeConsole();
            InitializeGame();
            DrawBorder();
            
            Game.Start();

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
                        Game.Player.CurrentDirection = Direction.Up; 
                        break;
                    case ConsoleKey.A: 
                        Game.Player.CurrentDirection = Direction.Left; 
                        break;
                    case ConsoleKey.S: 
                        Game.Player.CurrentDirection = Direction.Down; 
                        break;
                    case ConsoleKey.D: 
                        Game.Player.CurrentDirection = Direction.Right;
                        break;
                }
            }
        }

        static int Height = 20;
        static int Width = 20;
        static List<Point> LastPositions;
        static List<GameObject> GameObjects;
        static Game Game;

        public static void VisualiseFrame(object game, EventArgs args)
        {
            //if (LastPositions is null) Console.Clear();
            foreach (var position in LastPositions)
            {
                DrawChar(position, ' ');
            }

            LastPositions.Clear();
            foreach (var gameObject in GameObjects)
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
                else if (gameObject is Bonus) DrawChar(gameObject.Position, '+');
                
                if (gameObject is IMovable) LastPositions.Add(gameObject.Position);
            }

        }
        public static void InitializeConsole()
        {
            Console.Title = "Console Game";
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;

            int windowWidth = Width + 5;
            int windowHeight = Height + 5;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);
        }
        public static void InitializeGame()
        {
            LastPositions = new List<Point>();
            Game = new Game(Width, Height);
            GameObjects = Game.Field.Container;
            Game.GameUpdated += new GameUpdatedHandler(VisualiseFrame);
        }
        public static void DrawBorder()
        {
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Width);
                Console.Write('═');
            }
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Height, i);
                Console.Write('║');
            }
            Console.SetCursorPosition(Width, Height);
            Console.Write('╝');
        }
        public static Point ToConsolePoint(Point value, int maxHeight) => new Point(value.X, maxHeight - value.Y - 1);
        public static void DrawChar(Point position, char symbol)
        {
            Point consolePoint = ToConsolePoint(position, Height);
            Console.SetCursorPosition(consolePoint.X, consolePoint.Y);
            Console.Write(symbol);
        }
    }
}
