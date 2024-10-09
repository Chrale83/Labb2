public class Snake : Enemy
{
    public override char ElementForm { get { return 'S'; } }
    public override ConsoleColor ElementColor { get { return ConsoleColor.DarkGreen; } }
    public Snake(int x, int y) : base(x, y)
    {
        this.Name = "Snake";
        this.Hp = 2;
        this.DiceAttack = new Dice(3, 4, 2);
        this.DiceDefence = new Dice(1, 8, 5);
    }
    public override void Update(Player player, LevelData levelData)
    {
        int tempX = this.Position.X;
        int tempY = this.Position.Y;
        Console.SetCursorPosition(tempX, tempY);
        Console.Write(" ");
        // Formel för distans distance = √[(x2 − x1)2 + (y2 − y1)2
        double distance = Math.Sqrt(Math.Pow(this.Position.X - player.Position.X, 2) + Math.Pow(this.Position.Y - player.Position.Y, 2));
        if (distance <= 2)
        {
            int distanceX = tempX - player.Position.X;
            int distanceY = tempY - player.Position.Y;
            Move direction = CheckDirection(distanceX,distanceY);
            switch (direction)
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
    }
    public Move CheckDirection(int distanceX, int distanceY)
    {
        if (distanceY <= distanceX)
        {
            if (distanceY <= 0)
            {
                return Move.Down;
            }
            else if (distanceY >= 0)
            {
                return Move.Up;
            }
        }
        else
        {
            if (distanceX <= 0)
            {
                return Move.Left;
            }
            else if (distanceX >= 0)
            {
                return Move.Right;
            }
        }
        return Move.Right;
    }
}
 public enum Move
{
    Up,
    Down,
    Left,
    Right,
}
