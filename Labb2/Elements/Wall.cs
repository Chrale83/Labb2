class Wall : LevelElement
{
    public override char ObjectForm { get { return '#'; } }
    public override ConsoleColor ObjectColor { get { return ConsoleColor.DarkGray; } }
    public Wall(int x, int y) : base(x,y)
    {
    
    }
        
    //public override void Draw() //Här kan jag "Constructor chaining" ELLER INTE???
    //{
    //    Console.SetCursorPosition(this.ObjectPosition.XPosition, this.ObjectPosition.YPosition);
    //    Console.ForegroundColor = ObjectColor;
    //    Console.Write($"{this.ObjectForm}");
    //}



        


        
}


    





    

