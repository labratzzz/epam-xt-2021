using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    public class MovementAlgorithm
    {
        public int CurrentStep
        {
            get => CurrentStep;
            set => CurrentStep = (value >= StepList.Count) ? 0 : value;
        }
        public List<SimpleMovementsSequence> StepList { get; set; }

        public MovementAlgorithm()
        {
            StepList = new List<SimpleMovementsSequence>();
        }
        public Point GetNextPosition(Point current_position)
        {
            if (StepList[CurrentStep] is null)
            {
                CurrentStep++;
                return current_position;
            }
            else
            {
                CurrentStep++;
                return StepList[CurrentStep].Invoke(current_position);
            }
        }
    }

    public delegate Point SimpleMovementsSequence(Point current_position);

    static class SimpleMovements
    {

        public static Point StepLeft(Point current_position)
        {
            current_position.X -= 1;
            return current_position;
        }

        public static Point StepRight(Point current_position)
        {
            current_position.X += 1;
            return current_position;
        }

        public static Point StepUp(Point current_position)
        {
            current_position.Y += 1;
            return current_position;
        }

        public static Point StepDown(Point current_position)
        {
            current_position.Y -= 1;
            return current_position;
        }
    }

    public delegate void ContactHandler(object sender, ContactEventArgs args);

    public class ContactEventArgs
    {
        public ContactEventArgs(List<GameObject> contacted_with)
        {
            ContactedWith = contacted_with;
        }
        public List<GameObject> ContactedWith { get; private set; }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator ==(Point a, Point b) => (a.X == b.X && a.Y == b.Y);
        public static bool operator !=(Point a, Point b) => !(a.X == b.X && a.Y == b.Y);
    }

    interface IMovable
    {
        bool HasMadeMovementDecision { get; set; }
        void Move();
        event ContactHandler Contacted;
    }
}
