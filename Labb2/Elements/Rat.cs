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
    public override void Update() //Test <-------------
    {
        //int tempX = this.Position.X;
        //int tempY = this.Position.Y;
        //Console.SetCursorPosition(tempX, tempY);
        //Console.Write(" ");
        //Console.SetCursorPosition(tempX -= 1, tempY);

        //Console.Write(this.ElementForm);
        //this.Position = new Position(tempX,tempY);
    }
}
