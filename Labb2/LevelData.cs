public class LevelData
{
    private List<LevelElement> _elements;
    public Position PlayerStartPosition { get; set; }
    
    public List<LevelElement> Elements
    {
        get { return _elements; }
    }
    public LevelData() 
    {
        _elements = new List<LevelElement>();
    }
    
    public void LoadLevel(string levelPath)
    {
        string line;
        int tempYPos = 0;
        int offSetY = 3;
        using (StreamReader mapLoader = new StreamReader(levelPath))
        while ((line = mapLoader.ReadLine()) != null)
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
