public class Snake : Enemy
{
    public override char ElementForm { get { return 'S'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkGreen; } }
    public Snake(int x, int y) : base(x, y)
    {
        this.Name = "Snake";
        this.Hp = 100;
        this.DiceAttack = new Dice(3, 4, 2);
        this.DiceDefence = new Dice(1, 8, 5);
    }
    public override void Update()
    {
    }
}
