public class Rat : Enemy
{
    public override char ElementForm { get { return 'R'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkRed; } }
    public Rat(int x, int y) : base(x, y)
    {
        this.Name = "Rat";
        this.Hp = 30;
    }
    public override void Update()
    {

    }
}

   

