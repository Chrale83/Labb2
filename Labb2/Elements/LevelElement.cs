public abstract class LevelElement
{
    public abstract ConsoleColor ObjectColor{ get; }
    public abstract char ObjectForm{ get; }
    public Position Position { get; set; }
    public LevelElement(int x, int y)
    {
        this.Position = new Position(x, y);
    }
    public void Draw()
    {
        int offSetY = 2;
        Console.SetCursorPosition(this.Position.X, this.Position.Y + offSetY); 
        Console.ForegroundColor = this.ObjectColor;
        Console.Write($"{ObjectForm}");
    }
    
   

    
    
       
   


        





}

