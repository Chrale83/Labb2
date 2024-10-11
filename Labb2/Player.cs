public class Player : LevelElement
{
    public string Name { get { return "Christian";  } }
    public int Hp { get; set; }
    public Dice DiceAttack { get; set; }
    public Dice DiceDefence { get; set; }
    
    public override char ElementForm { get { return '@'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.Yellow; } }
    public Player(Position startPosition) : base(startPosition.X, startPosition.Y)
    {
        DiceAttack = new Dice(2, 6, 2);
        DiceDefence = new Dice(2, 6, 0);
        this.Hp = 100;
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.ForegroundColor = this.ElementColor;
        Console.Write(this.ElementForm);
    }
}