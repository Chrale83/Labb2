using Labb2;

public class GameLoop
{
    public void GameRun()
    {
        LevelData levelData = new LevelData();
        levelData.LoadLevel();
        foreach (var item in levelData.Elements)
        {
            item.Draw();
        }
        Player player = new Player(levelData.PlayerStartPosition);
        int turn = 0;
        while (true)
        {
            PlayerStats(player, turn++);
            PlayerTurn(player, levelData);
            EnemyTurn(levelData);

            //Spelar statsen skrivs ut
            //Spelaren gör nåt
            //En turn
            //Fienden rör sig
        }
    }
    public void PlayerTurn(Player player, LevelData levelData) //-----> Flytta denna till PlayerAction??? <----
    {
        int tempX = player.Position.X;
        int tempY = player.Position.Y;
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(" ");
        switch (keyPressed.Key)
        {
            case ConsoleKey.LeftArrow:
                tempX -= PlayerAction.MoveLeft(tempX, tempY, levelData, player);
                break;
            case ConsoleKey.RightArrow:
                tempX += PlayerAction.MoveRight(tempX, tempY, levelData, player);
                break;
            case ConsoleKey.UpArrow:
                tempY -= PlayerAction.MoveUpp(tempX, tempY, levelData, player);
                break;
            case ConsoleKey.DownArrow:
                tempY += PlayerAction.MoveDown(tempX, tempY, levelData, player);
                break;
            default:
                break;
        }
        Console.SetCursorPosition(tempX, tempY);
        player.Position = new Position(tempX, tempY);
        
        Console.ForegroundColor = player.ElementColor;
        Console.Write(player.ElementForm);
    }
    public void PlayerStats(Player player, int turn)
    {
        Console.SetCursorPosition(0, 20);
        Console.WriteLine($"playername: {player.Name} Hp:{player.PlayerHp} Turns: {turn}"); //Här ska omgångräknaren står, spelarensnamn, samt spelarens Hp
    }

    public void EnemyTurn(LevelData levelData)
    {
        foreach (var item in levelData.Elements)
        {
            if (item is Enemy)
            {
                Enemy enemy = item as Enemy;
                enemy.Update();
                //PlayerAction.CheckIfSpace(enemy.Position.X, enemy.Position.Y, levelData);

            }
        }
    }
}
