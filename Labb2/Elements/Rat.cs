public class Rat : Enemy
{
    public override char ObjectForm { get { return 'R'; } }
    public override ConsoleColor ObjectColor { get { return ConsoleColor.DarkRed; } }
    public Rat(int x, int y) : base(x, y)
    {
        this.Name = "Snake";
        this.Hp = 25;
    }
    public override void Update()
    {

    }
}

   

