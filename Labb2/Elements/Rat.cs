public class Rat : Enemy
{
    public override char ElementForm { get { return 'R'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkRed; } }
    public Rat(int x, int y) : base(x, y)
    {
        this.Name = "Rat";
        this.Hp = 30;
        this.DiceAttack = new Dice(1, 6, 3);
        this.DiceDefence = new Dice(1, 6, 1);
    }
    public override void Update(Player player, LevelData levelData) //Test <-------------
    {
        Random random = new Random();
        int randMove = random.Next(0, 4);
        Move direction = (Move)randMove;
        int tempX = this.Position.X;
        int tempY = this.Position.Y;
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(" ");
        Movement(tempX, tempY, levelData, player, direction);
    }
}