using System;
using System.Collections.Generic;
using System.Threading;

namespace GameLib
{
    public delegate void GameUpdatedHandler(object sender, EventArgs args);

    public class Game
    {
        private Timer Timer;
        public GameField Field { get; }
        public event GameUpdatedHandler GameUpdated;
        public Player Player;

        public Game(int width, int height)
        {
            Field = new GameField(width, height);
            //Timer.Interval = 1000; //ms = 1s
            Player = new Player(20) { Position = new Point(10, 10) };
        }

        public void Start()
        {
            //Field.Container.Add();
            Field.Container.Add(Player);
            Timer = new Timer(NextFrame, null, 0, 1000);
        }

        //private Place<>

        //or Step()
        private void NextFrame(object sender)
        {
            foreach (var obj in Field.Container)
            {
                if (obj is IMovable) (obj as IMovable).Move();
            }

            GameUpdated?.Invoke(this, new EventArgs());
            //call Move() method of all movable objects
            //move method returns new position of an object
            //search new position in positions of all objects
            //if a match founded - raise Contact event
        }

        public void Pause()
        {
            //Timer.Stop();
        }

        public void Stop() 
        {
        
        }
    }

    public class GameField
    {
        private int width;
        private int height;
        public int Width
        {
            get => width;
            set => width = (value > 5) ? value : throw new ArgumentException();
        }
        public int Height
        {
            get => height;
            set => height = (value > 5) ? value : throw new ArgumentException();
        }

        public int MaxObjectsCount { get; set; }
        private List<GameObject> container;
        public List<GameObject> Container
        {
            get => container;
            set => container = (value.Count <= MaxObjectsCount) ? value : throw new ArgumentException();
        }
        
        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            MaxObjectsCount = width * height;
            Container = new List<GameObject>();
        }
    }
}