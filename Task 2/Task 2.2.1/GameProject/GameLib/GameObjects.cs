namespace GameLib
{
    using System.Collections.Generic;

    // Abstract classes
    public abstract class GameObject
    {
        // Constructors
        protected GameObject(Point position, GameField field)
        {
            this.Position = position;
            this.Field = field;
        }
        
        // Properties
        public Point Position { get; set; }

        protected GameField Field { get; set; }
    }

    // Classes
    public class Enemy : GameObject, IComputedMovable
    {
        // Constructors
        public Enemy(Point position, GameField field) : base(position, field)
        {

        }

        #region IComputedMovable implementation
        // Events
        public event ContactHandler Contacted;

        public event OutOfBoundsHandler MovedOutOfBounds;

        // Properties
        public bool HasMadeMovementDecision { get; set; }

        public MovementAlgorithm Algorithm { get; set; }

        // Methods
        public void Move()
        {
            Point previousPosition = this.Position;

            Point newPosition = this.Algorithm.GetNextPosition(Position);
            this.Position = newPosition;

            if (this.Field.DetectMovingOutOfBounds)
            {
                this.CheckUpForOutOfBounds(previousPosition);
            }

            this.CheckUpForContacts();

            this.HasMadeMovementDecision = true;
        }

        protected void CheckUpForOutOfBounds(Point previousPosition)
        {
            if (this.Position.X < this.Field.LeftBound)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Left);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.X >= this.Field.Width)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Right);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.Y < this.Field.BottomBound)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Bottom);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.Y >= this.Field.Height)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Top);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
        }

        protected void CheckUpForContacts()
        {
            foreach (var gameObject in this.Field.Container)
            {
                List<GameObject> contactedWith = new List<GameObject>();
                if (this.Position == gameObject.Position)
                {
                    if (gameObject is IMovable && !(gameObject as IMovable).HasMadeMovementDecision)
                    {
                        continue;
                    }

                    contactedWith.Add(gameObject);
                }

                if (contactedWith.Count != 0)
                {
                    this.Contacted?.Invoke(this, new ContactEventArgs(contactedWith));
                }
            }
        }
        #endregion

        // Propeties
        public int Damage { get; set; }

        // Methods
        public void Hurt(Player player)
        {
            player.HealthPoints -= this.Damage;
        }
    }

    public class Player : GameObject, IControlledMovable
    {
        // Constructors
        public Player(Point position, GameField field, int healthPoints) : base(position, field)
        {
            this.HealthPoints = healthPoints;
            this.CurrentDirection = Direction.Up;
            this.Step = 1;
        }

        #region IControlledMovable implementation
        // Events
        public event ContactHandler Contacted;

        public event OutOfBoundsHandler MovedOutOfBounds;

        // Properties
        public bool HasMadeMovementDecision { get; set; }

        public Direction CurrentDirection { get; set; }

        public int Step { get; set; }

        // Methods
        public void Move()
        {
            Point previousPosition = this.Position;
            
            Point newPosition = this.Position;
            switch (this.CurrentDirection)
            {
                default:
                    break;
                case Direction.Up:
                    newPosition.Y += this.Step;
                    break;
                case Direction.Down:
                    newPosition.Y -= this.Step;
                    break;
                case Direction.Right:
                    newPosition.X += this.Step;
                    break;
                case Direction.Left:
                    newPosition.X -= this.Step;
                    break;
            }

            this.Position = newPosition;

            if (this.Field.DetectMovingOutOfBounds)
            {
                this.CheckUpForOutOfBounds(previousPosition);
            }

            this.CheckUpForContacts();

            this.HasMadeMovementDecision = true;
        }

        protected void CheckUpForOutOfBounds(Point previousPosition)
        {
            if (this.Position.X < this.Field.LeftBound)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Left);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.X >= this.Field.Width)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Right);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.Y < this.Field.BottomBound)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Bottom);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
            else if (this.Position.Y >= this.Field.Height)
            {
                OutOfBoundsEventArgs eventArgs = new OutOfBoundsEventArgs(previousPosition, Sides.Top);
                this.MovedOutOfBounds?.Invoke(this, eventArgs);
            }
        }

        protected void CheckUpForContacts()
        {
            foreach (var gameObject in this.Field.Container)
            {
                List<GameObject> contactedWith = new List<GameObject>();
                if (this.Position == gameObject.Position)
                {
                    if (gameObject is IMovable && !(gameObject as IMovable).HasMadeMovementDecision)
                    {
                        continue;
                    }

                    contactedWith.Add(gameObject);
                }

                if (contactedWith.Count != 0) this.Contacted?.Invoke(this, new ContactEventArgs(contactedWith));
            }
        }
        #endregion

        // Properties
        public int HealthPoints { get; set; }
    }

    public class Bonus : GameObject
    {
        // Constructors
        public Bonus(Point position, GameField field) : base(position, field)
        {

        }
    }

    public class Obstacle : GameObject
    {
        // Constructors
        public Obstacle(Point position, GameField field) : base(position, field)
        {

        }
    }
}