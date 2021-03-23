using System.Collections.Generic;

namespace GameLib
{
    public class GameObject
    {
        public Point Position { get; set; }
        protected GameField Field { get; set; }
    }

    public class Enemy : GameObject, IMovable
    {
        public int Damage { get; set; }
        public MovementAlgorithm Algorithm { get; set; }
        public bool HasMadeMovementDecision { get; set; }
        public event ContactHandler Contacted;

        public void Move()
        {
            Point NewPosition = Algorithm.GetNextPosition(Position);

            if (NewPosition.X >= Field.Width) NewPosition.X = Field.Width - 1;
            if (NewPosition.X < 0) NewPosition.X = 0;
            if (NewPosition.Y >= Field.Height) NewPosition.Y = Field.Height - 1;
            if (NewPosition.Y < 0) NewPosition.Y = 0;

            Position = NewPosition;

            foreach (var GameObject in Field.Container)
            {
                List<GameObject> contacted_with = new List<GameObject>();
                if (this.Position == GameObject.Position)
                {
                    if (GameObject is IMovable && (GameObject as IMovable).HasMadeMovementDecision == false) continue;
                    contacted_with.Add(GameObject);
                }
                Contacted?.Invoke(this, new ContactEventArgs(contacted_with));
            }

            HasMadeMovementDecision = true;
        }

        public void Hurt(Player player)
        {
            player.HealthPoints -= Damage;
        }
    }

    public class Player : GameObject, IMovable
    {
        public Player(int health_points)
        {
            HealthPoints = health_points;
            CurrentDirection = Direction.Up;
        }
        public int HealthPoints { get; set; }
        public Direction CurrentDirection { get; set; }
        public int Step { get; set; }
        public bool HasMadeMovementDecision { get; set; }
        public event ContactHandler Contacted;

        public void Move()
        {
            Point NewPosition = Position;

            switch (CurrentDirection)
            {
                default:
                    break;
                case Direction.Up:
                    NewPosition.Y = (Position.Y + Step >= Field.Height) ? 0 : Step;
                    break;
                case Direction.Down:
                    NewPosition.Y = (Position.Y - Step >= Field.Height) ? 0 : Step;
                    break;
                case Direction.Left:
                    NewPosition.X = (Position.X - Step >= Field.Height) ? 0 : Step;
                    break;
                case Direction.Right:
                    NewPosition.X = (Position.X + Step >= Field.Height) ? 0 : Step;
                    break;
            }

            Position = NewPosition;

            foreach (var GameObject in Field.Container)
            {
                List<GameObject> contacted_with = new List<GameObject>();
                if (this.Position == GameObject.Position)
                {
                    if (GameObject is IMovable && (GameObject as IMovable).HasMadeMovementDecision == false) continue;
                    contacted_with.Add(GameObject);
                }
                Contacted?.Invoke(this, new ContactEventArgs(contacted_with));
            }

            HasMadeMovementDecision = true;
        }
    }

    public class Bonus : GameObject
    {

    }

    public class Obstacle : GameObject
    {

    }
}