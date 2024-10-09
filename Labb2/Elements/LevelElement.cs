public abstract class LevelElement
{
    public abstract ConsoleColor ElementColor { get; }
    public abstract char ElementForm { get; }
    public Position Position { get; set; }
    public LevelElement(int x, int y)
    {
        this.Position = new Position(x, y);
    }
    public void Draw(Player playerPosition)
    {
        double distance = Math.Sqrt(Math.Pow(playerPosition.Position.X - Position.X, 2) + Math.Pow(playerPosition.Position.Y - Position.Y, 2));
        
        if (distance <= 5)
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.ForegroundColor = this.ElementColor;
            Console.Write($"{ElementForm}");

        }
        if (this is Enemy && distance > 5)
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" ");
        }


    }
    public virtual void Draw() { }
}
