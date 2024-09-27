class Program
{
    static void Main(string[] args)
    {
        LevelData loadLevel = new LevelData();
        loadLevel.LoadLevel();

        foreach (var item in loadLevel.Elements)
        {
            item.Draw();
        }
        
        

        
    }
}



