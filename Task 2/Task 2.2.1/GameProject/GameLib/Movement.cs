namespace GameLib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // Delegates
    public delegate void ContactHandler(object sender, ContactEventArgs args);

    public delegate void OutOfBoundsHandler(object sender, OutOfBoundsEventArgs args);

    public delegate Point SimpleMovementsSequence(Point currentPosition);

    // Enums
    public enum Sides
    {
        Top,
        Bottom,
        Right,
        Left
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    // Interfaces
    public interface IMovable
    {
        // Events
        event ContactHandler Contacted;

        event OutOfBoundsHandler MovedOutOfBounds;

        // Properties
        bool HasMadeMovementDecision { get; set; }

        // Methods
        void Move();
    }

    public interface IComputedMovable
    {
        // Properties
        MovementAlgorithm Algorithm { get; set; }
    }

    public interface IControlledMovable
    {
        // Properties
        Direction CurrentDirection { get; set; }

        int Step { get; set; }
    }

    // Structures
    public struct Point
    {
        // Constructors
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Properties
        public int X { get; set; }

        public int Y { get; set; }

        // Methods
        public static bool operator ==(Point a, Point b) => (a.X == b.X && a.Y == b.Y);

        public static bool operator !=(Point a, Point b) => !(a.X == b.X && a.Y == b.Y);

        public override string ToString() => string.Format("({0}, {1})", this.X, this.Y);
    }

    // Classes
    public static class SimpleMovements
    {
        // Methods
        public static Point StepLeft(Point currentPosition)
        {
            currentPosition.X -= 1;
            return currentPosition;
        }

        public static Point StepRight(Point currentPosition)
        {
            currentPosition.X += 1;
            return currentPosition;
        }

        public static Point StepUp(Point currentPosition)
        {
            currentPosition.Y += 1;
            return currentPosition;
        }

        public static Point StepDown(Point currentPosition)
        {
            currentPosition.Y -= 1;
            return currentPosition;
        }

        public static Point StandStill(Point currentPosition)
        {
            return currentPosition;
        }
    }

    public class MovementAlgorithm
    {
        // Fields
        private int currentStep;

        // Constructors
        public MovementAlgorithm()
        {
            this.StepList = new List<SimpleMovementsSequence>();
        }

        // Properties
        public int CurrentStep
        {
            get => this.currentStep;
            set => this.currentStep = (value >= this.StepList.Count) ? 0 : value;
        }

        public List<SimpleMovementsSequence> StepList { get; set; }

        // Methods
        public Point GetNextPosition(Point currentPosition)
        {
            if (this.StepList[this.CurrentStep] is null)
            {
                this.CurrentStep++;
                return currentPosition;
            }
            else
            {
                this.CurrentStep++;
                return this.StepList[this.CurrentStep].Invoke(currentPosition);
            }
        }
    }

    // EventArgs
    public class ContactEventArgs
    {
        // Constructors
        public ContactEventArgs(List<GameObject> contactedWith)
        {
            this.ContactedWith = contactedWith;
        }

        // Properties
        public List<GameObject> ContactedWith { get; private set; }
    }

    public class OutOfBoundsEventArgs
    { 
        // Constructors
        public OutOfBoundsEventArgs(Point previousPosition, Sides sideCrossed)
        {
            this.PreviousPosition = previousPosition;
            this.SideCrossed = sideCrossed;
        }

        // Properties
        public Point PreviousPosition { get; private set; }

        public Sides SideCrossed { get; private set; }
    }
}
