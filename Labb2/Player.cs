class Player : LevelElement
{
    public string Name { get { return "Knight"; } }
    public int PlayerHp { get { return 100; } }
        
    public Dice DiceAttack { get; set; }
    public Dice DiceDefence { get; set; }

    public override char ObjectForm { get { return '@'; } }
    public override ConsoleColor ObjectColor { get { return ConsoleColor.Yellow; } }
    public Player(int x, int y) : base(x, y)
    {

    }




}
