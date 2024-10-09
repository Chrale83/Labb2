public class Rat : Enemy
{
    public override char ElementForm { get { return 'R'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkRed; } }
    public Rat(int x, int y) : base(x, y)
    {
        this.Name = "Rat";
        this.Hp = 30;
        this.DiceAttack = new Dice(1, 6, 3);
        this.DiceDefence = new Dice(1, 6, 1);
    }
    public override void Update(Player player, LevelData levelData) //Test <-------------
    {
        Random random = new Random();
        int randMove = random.Next(0, 4);
        Move MoveDirection = (Move)randMove;
        int tempX = this.Position.X;
        int tempY = this.Position.Y;
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(" ");

        switch (MoveDirection)
        {
            case Move.Up:
                if (CheckIfSpaceEnemy(tempX, tempY - 1, levelData, player, this))
                {
                    tempY -= 1;

                }
                break;
            case Move.Down:
                if (CheckIfSpaceEnemy(tempX, tempY + 1, levelData, player, this))
                {
                    tempY += 1;
                }

                break;
            case Move.Left:
                if (CheckIfSpaceEnemy(tempX - 1, tempY, levelData, player, this))
                {
                tempX -= 1;

                }
                break;
            case Move.Right:
                if (CheckIfSpaceEnemy(tempX + 1, tempY, levelData, player, this))
                {
                    tempX += 1;
                }
                
                break;
        }
        this.Position = new Position(tempX, tempY);
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(this.ElementForm);
        
    }
    enum Move
    {
        Up,
        Down,
        Left,
        Right,
    }
}
            


        

