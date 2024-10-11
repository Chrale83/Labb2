using Labb2;
public class GameLoop
{
    private bool runGame = true;
    public LevelData GameLevelData { get; set; }
    public Player ActivePlayer { get; set; }
    public int Turn { get; set; }

    public GameLoop(string levelPath)
    {
        this.Turn = 0;
        this.GameLevelData = new LevelData();
        this.GameLevelData.LoadLevel(levelPath);
        this.ActivePlayer = new Player(GameLevelData.PlayerStartPosition);
    }
    public void GameRun()
    {
        FirstStartInfo();
        while (runGame)
        {
            PlayerInfo();
            DrawMap();
            PlayerTurn();
            EnemyTurn();
        }
    }

    public void FirstStartInfo()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.SetCursorPosition(20, 5); Console.WriteLine("Använd pil tagenterna för att flytta spelaren");
        Console.SetCursorPosition(29, 6); Console.WriteLine("Space för att hoppa en runda");
        Console.SetCursorPosition(30, 7); Console.WriteLine("ESC för att avsluta spelet");
        Console.SetCursorPosition(22, 9); Console.WriteLine("Tryck valfri tagent för att starta spelet");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }

    public void DrawMap()
    {
        ActivePlayer.Draw();
        foreach (var item in GameLevelData.Elements)
        {
            item.Draw(ActivePlayer);
        }
    }

    public void PlayerTurn() //-----> Flytta denna till GameAction eller player???? <----
    {
        if (ActivePlayer.Hp <= 0)
        {
            runGame = false;
        }

        int tempX = ActivePlayer.Position.X;
        int tempY = ActivePlayer.Position.Y;
        bool isValidKey = false;

        while (!isValidKey)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            Console.SetCursorPosition(tempX, tempY);
            Console.Write(" ");
            switch (keyPressed.Key)
            {
                case ConsoleKey.LeftArrow:
                    tempX -= GameAction.MoveLeft(tempX, tempY, GameLevelData, ActivePlayer);
                    isValidKey = true;
                    break;
                case ConsoleKey.RightArrow:
                    tempX += GameAction.MoveRight(tempX, tempY, GameLevelData, ActivePlayer);
                    isValidKey = true;
                    break;
                case ConsoleKey.UpArrow:
                    tempY -= GameAction.MoveUpp(tempX, tempY, GameLevelData, ActivePlayer);
                    isValidKey = true;
                    break;
                case ConsoleKey.DownArrow:
                    tempY += GameAction.MoveDown(tempX, tempY, GameLevelData, ActivePlayer);
                    isValidKey = true;
                    break;
                case ConsoleKey.Spacebar:
                    isValidKey = true;
                    break;
                case ConsoleKey.Escape:
                    runGame = false;
                    isValidKey = true;
                    break;
                default:
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Du använder piltagenterna för att styra och ESC för att avsluta spelet");
                    break;
            }
        }
        ActivePlayer.Position = new Position(tempX, tempY);

    }
    public void PlayerInfo()
    {
        GameAction.ClearStatInfo();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, 0);

        Console.WriteLine($"{ActivePlayer.Name} - Hp:{ActivePlayer.Hp}/100 - Turns: {Turn++}");
        Console.ResetColor();
    }
    public void EnemyTurn()
    {
        for (int i = GameLevelData.Elements.Count - 1; i >= 0; i--)
        {
            if (GameLevelData.Elements[i] is Enemy enemy)
            {
                if (enemy.Hp <= 0)
                {
                    GameLevelData.Elements.RemoveAt(i);
                }
                else
                {
                    enemy.Update(ActivePlayer, GameLevelData);
                }
            }
        }
    }
}