using System.Runtime.CompilerServices;

class Snake : Enemy
{

    
    public override char ObjectForm { get { return 'S'; } }
    public override ConsoleColor ObjectColor { get { return ConsoleColor.DarkGreen; } }

    public Snake(int x, int y) : base(x, y)
    {
        this.ObjectPosition = new Position(x, y);
        this.Name = "Snake";
        this.Hp = 100;
    }
        

    public override void Update()
{

}
}
    
