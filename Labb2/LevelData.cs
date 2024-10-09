public class LevelData
{
    private List<LevelElement> _elements;
    public Position PlayerStartPosition { get; set; }
    public List<LevelElement> Elements
    {
        get { return _elements; }
    }
    public LevelData() //Konstruktorn
    {
        _elements = new List<LevelElement>();
    }
    public void LoadLevel(string levelPath) //Läser in text filen och skapar objekt av respektive tecken
    {
        //_elements = new List<LevelElement>();
        string path = Directory.GetCurrentDirectory();
        string fullPath = path + @"\labb2\levels\level1.txt";
        string line;
        int tempYPos = 0;
        int offSetY = 3;
        using (StreamReader streamReader = new StreamReader(levelPath))
        while ((line = streamReader.ReadLine()) != null)
        {
            for (int tempXPos = 0; tempXPos < line.Length; tempXPos++)
            {
                switch (line[tempXPos])
                {
                    case '#':
                        Elements.Add(new Wall(tempXPos, tempYPos + offSetY));
                        break;
                    case 's':
                        Elements.Add(new Snake(tempXPos, tempYPos + offSetY));
                        break;
                    case 'r':
                        Elements.Add(new Rat(tempXPos, tempYPos + offSetY));
                        break;
                    case '@':
                        PlayerStartPosition = new Position(tempXPos, tempYPos + offSetY);
                        break;
                    default:
                        break;
                }
            }
            tempYPos++;
        }
    }
}
