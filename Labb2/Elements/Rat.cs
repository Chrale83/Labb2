class Rat : Enemy
{

    //private char _objectForm = 'R';
    //private ConsoleColor _objectColor = ConsoleColor.DarkRed;
    public override char ObjectForm { get { return 'R'; } }
    public override ConsoleColor ObjectColor { get { return ConsoleColor.DarkRed; } }
    public Rat(int x, int y) : base(x, y)
    {
        this.ObjectPosition = new Position(x, y);
    }
    public override void Update()
    {

    }
        

}