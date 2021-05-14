namespace GameLib
{
    public class RegularEnemy : Enemy
    {
        public RegularEnemy(Point position) : base(position)
        {
            this.Damage = 10;
            this.Algorithm = new MovementAlgorithm();
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepLeft));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepLeft));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepUp));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepUp));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepRight));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepRight));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepRight));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepDown));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepDown));
            Algorithm.StepList.Add(new SimpleMovementsSequence(SimpleMovements.StepDown));
        }
    }
}