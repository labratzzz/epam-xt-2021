namespace GameLib
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    public delegate void GameUpdatedHandler(object sender, EventArgs args);
    
    public class Game
    {
        // Fields
        private readonly Timer timer;

        // Constructors
        public Game(int width, int height)
        {
            this.Field = new GameField(width, height, this);
            this.timer = new Timer(400); // ms = 0.4s 
            this.timer.Elapsed += new ElapsedEventHandler(this.NextFrame);
            this.Player = new Player(new Point(10, 10), this.Field, 100);
            this.Player.MovedOutOfBounds += new OutOfBoundsHandler(this.OnObjectMovedOutOfBounds);
        }

        // Events
        public event GameUpdatedHandler GameUpdated;

        // Properties
        public GameField Field { get; }

        public Player Player { get; set; }

        // Methods
        public void Start()
        {
            this.timer.Start();
        }

        public void Pause()
        {
            this.timer.Stop();
        }

        private void NextFrame(object sender, ElapsedEventArgs args)
        {
            var gamefield = this.Field.Container;
            foreach (var obj in gamefield)
            {
                if (obj is IMovable)
                {
                    (obj as IMovable).Move();
                }
            }

            this.GameUpdated?.Invoke(this, new EventArgs());
        }

        private void OnObjectContact(object sender, ContactEventArgs args)
        { 
        
        }

        private void OnObjectMovedOutOfBounds(object sender, OutOfBoundsEventArgs args)
        {
            (sender as GameObject).Position = args.PreviousPosition;
        }
    }

    public class GameField
    {
        // Constructors
        public GameField(int width, int height, Game game, bool detectMovingOutOfBounds = true)
        {
            this.LeftBound = 0;
            this.BottomBound = 0;

            this.Width = width;
            this.Height = height;
            this.MaxObjectsCount = width * height;
            this.Container = new List<GameObject>();
            this.Game = game;
            this.DetectMovingOutOfBounds = detectMovingOutOfBounds;
        }

        // Properties
        public int LeftBound { get; protected set; }

        public int BottomBound { get; protected set; }

        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public int MaxObjectsCount { get; protected set; }

        public List<GameObject> Container { get; protected set; }

        public bool DetectMovingOutOfBounds { get; protected set; }

        public Game Game { get; protected set; }

        // Methods
        public void Add(GameObject gameObject)
        {
           
        }
    }
}