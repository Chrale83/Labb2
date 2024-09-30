

public class LevelData
{
    private List<LevelElement> _elements;
    public List<LevelElement> Elements
    {
        get { return _elements; }
    }
    public LevelData() //Konstruktorn
    {
        _elements = new List<LevelElement>();
    }
    public void LoadLevel() //Läser in text filen och skapar objekt
    {
        string level = @"C:\Users\Chral\source\repos\NET24\Csharp\Labb2\Labb2\Levels\Level1.txt";
        StreamReader streamReader = new StreamReader(level);
        string line;
        int tempYPos = 0;

        while ((line = streamReader.ReadLine()) != null)
        {
        for (int tempXPos = 0; tempXPos < line.Length; tempXPos++)
        {

                switch (line[tempXPos])
                {
                    case '#':
                        Elements.Add(new Wall(tempXPos, tempYPos));
                        break;
                    case 's':
                        Elements.Add(new Snake(tempXPos, tempYPos));
                        break;
                    case 'r':
                        Elements.Add(new Rat(tempXPos, tempYPos));
                        break;
                    case '@':
                        Player myPlayer = new Player(tempXPos, tempYPos);
                        Elements.Add(myPlayer);
                        break;
                    default:
                        break;
                }
            }
            tempYPos++;
            Console.WriteLine();
        }
        foreach (var item in Elements)
        {
            item.Draw();
        }
    }

                

    
}
            





      

       

