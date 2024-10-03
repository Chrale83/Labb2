public class Player : LevelElement
{
    public string Name { get { return "Dräparen"; } }
    public int PlayerHp { get { return 100; } }
    public Dice DiceAttack { get; set; }
    public Dice DiceDefence { get; set; }
    public override char ElementForm { get { return '@'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.Yellow; } }
    public Player(Position startPosition) : base(startPosition.X, startPosition.Y)
    {
        DiceAttack = new Dice(2, 6, 2);
        DiceDefence = new Dice(2, 6, 0);
    }
}
