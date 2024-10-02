using Labb2;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

public class GameLoop
{
    public void GameRun()
    {
        LevelData loadLevel = new LevelData();
        loadLevel.LoadLevel();


        foreach (var item in loadLevel.Elements)
        {
            item.Draw();
        }
        

        Player player = new Player(loadLevel.PlayerStartPosition);

        int turn = 0;
        while (true)
        {
            PlayerTurn(player, loadLevel);
            PlayerStats(player, turn++);
            //Update()

            //Spelar statsen skrivs ut
            //Spelaren gör nåt
            //En turn
            //Fienden rör sig
        }
    }



    public void PlayerTurn(Player player, LevelData levelData)
    {
        int playerPositionX = player.Position.X;
        int playerPositionY = player.Position.Y;

        ConsoleKeyInfo keyPressed = Console.ReadKey();
        Console.SetCursorPosition(playerPositionX, playerPositionY);
        Console.Write(" ");

        switch (keyPressed.Key)
        {
            case ConsoleKey.LeftArrow:

                playerPositionX -= PlayerAction.MoveLeft(playerPositionX, playerPositionY, levelData);
                break;
            case ConsoleKey.RightArrow:
                playerPositionX += PlayerAction.MoveRight(playerPositionX, playerPositionY, levelData);
                break;
            case ConsoleKey.UpArrow:
                playerPositionY -= PlayerAction.MoveUpp(playerPositionX, playerPositionY, levelData);
                break;
            case ConsoleKey.DownArrow:

                playerPositionY += PlayerAction.MoveDown(playerPositionX, playerPositionY, levelData);
                break;
            default:
                break;
        }

        Console.SetCursorPosition(playerPositionX, playerPositionY);
        player.Position = new Position(playerPositionX, playerPositionY);
        Console.ForegroundColor = player.ElementColor;
        Console.Write(player.ElementForm);
    }
    public void PlayerStats(Player player, int turn)
    {

        Console.SetCursorPosition(0, 20);
        Console.WriteLine($"{player.Name} ; {player.PlayerHp}, {turn}"); //Här ska omgångräknaren står, spelarensnamn, samt spelarens Hp
    }
}
























