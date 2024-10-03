public abstract class LevelElement
{
    public abstract ConsoleColor ElementColor{ get; }
    public abstract char ElementForm{ get; }
    public Position Position { get; set; }
    public LevelElement(int x, int y)
    {
        this.Position = new Position(x, y);
    }
    public void Draw()
    {
        Console.SetCursorPosition(this.Position.X, this.Position.Y); 
        Console.ForegroundColor = this.ElementColor;
        Console.Write($"{ElementForm}");
    }
}
