namespace GameLib
{
    public class Hero : Player
    {
        public Hero(Point position) : base(position)
        {
            this.CurrentDirection = Direction.Up;
            this.HealthPoints = 100;
        }
    }
}