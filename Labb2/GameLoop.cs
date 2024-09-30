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
        

        PlayerMove(player);
        

        

        while (true)
        {
            //PlayerTurn()
            //Update()

            //Spelar statsen skrivs ut
            //Spelaren gör nåt
            //En turn
            //Råttan rör sig
        }
    }
    public void PlayerTurn()
    {
        

    }

    public void PlayerMove(Player player)
    {
        int playerPositionX = player.Position.X;
        int playerPositionY = player.Position.Y;
        LevelData map = new LevelData();



        while (true)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(" ");


            switch (keyPressed.Key)
            {
                case ConsoleKey.LeftArrow:
                    playerPositionX -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    playerPositionX += 1;
                    break;
                case ConsoleKey.UpArrow:
                    playerPositionY -= 1;
                    break;
                case ConsoleKey.DownArrow:

                    playerPositionY += 1;
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.ForegroundColor = player.ObjectColor;
            Console.Write(player.ObjectForm);
        }
    }



    public void PlayerStats(Player player, int turn)
    {

        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"{player.Name} ; {player.PlayerHp}, {turn}"); //Här ska omgångräknaren står, spelarensnamn, samt spelarens Hp
    }

}
           
        

        
        
