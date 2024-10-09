using Labb2;
using System.Security.Cryptography.X509Certificates;
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
        while (runGame)
        {
            
            DrawMap();
            PlayerInfo();
            PlayerTurn();
            EnemyTurn();
            
            
        }
    }
    public void DrawMap()
    {
        foreach (var item in GameLevelData.Elements)
        {
            item.Draw(ActivePlayer);
        }
    }
    public void PlayerTurn() //-----> Flytta denna till PlayerAction??? <----
    {
        int tempX = ActivePlayer.Position.X;
        int tempY = ActivePlayer.Position.Y;
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(" ");
        switch (keyPressed.Key)
        {
            case ConsoleKey.LeftArrow:
                tempX -= GameAction.MoveLeft(tempX, tempY, GameLevelData, ActivePlayer);
                break;
            case ConsoleKey.RightArrow:
                tempX += GameAction.MoveRight(tempX, tempY, GameLevelData, ActivePlayer);
                break;
            case ConsoleKey.UpArrow:
                tempY -= GameAction.MoveUpp(tempX, tempY, GameLevelData, ActivePlayer);
                break;
            case ConsoleKey.DownArrow:
                tempY += GameAction.MoveDown(tempX, tempY, GameLevelData, ActivePlayer);
                break;
            case ConsoleKey.Spacebar:
                
                break;
            case ConsoleKey.Escape:
                runGame = false;
                break;
            default:
                break;
        }
        Console.SetCursorPosition(tempX, tempY);
        ActivePlayer.Position = new Position(tempX, tempY);
        Console.ForegroundColor = ActivePlayer.ElementColor;
        Console.Write(ActivePlayer.ElementForm);
        Console.ResetColor();
    }
    public void PlayerInfo()
    {
        if (ActivePlayer.Hp <= 0)
        {
            runGame = false;
        }
        ClearStatInfo();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, 0);
        
        Console.WriteLine($"{ActivePlayer.Name} - Hp:{ActivePlayer.Hp} - Turns: {Turn++}"); //Här ska omgångräknaren står, spelarensnamn, samt spelarens Hp
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

    //https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
    public void ClearStatInfo()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(new string(' ', Console.WindowWidth));
    }
}
