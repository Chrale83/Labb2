public abstract class LevelElement
{
    public abstract ConsoleColor ObjectColor
    {
        get;
    }

    public abstract char ObjectForm
    {
        get;
    }

    public Position ObjectPosition { get; set; }

    public LevelElement(int x, int y)
    {
        this.ObjectPosition = new Position(x, y);
    }
    public void Draw()
    {
        Console.SetCursorPosition(this.ObjectPosition.XPosition, this.ObjectPosition.YPosition + 3);
        Console.ForegroundColor = this.ObjectColor;
        Console.Write($"{ObjectForm}");
    }
        





}

