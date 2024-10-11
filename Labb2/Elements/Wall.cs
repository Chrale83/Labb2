public class Wall : LevelElement
{
    public override char ElementForm { get { return '#'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkGray; } }
    public Wall(int x, int y) : base(x,y)
    {
    
    }
}