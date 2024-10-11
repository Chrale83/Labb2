using Labb2;
using System.Data;
using System.Numerics;
public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public Dice DiceAttack { get; set; }
    public Dice DiceDefence { get; set; }
    public Enemy(int x, int y) : base(x, y)
    {
    }
    public abstract void Update(Player player, LevelData levelData);

    public void Movement(int tempX, int tempY, LevelData levelData, Player player, Move direction)  //<---------------- MAGISKA NUMMER I SWITCH SATSEN!
    {
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
        
    }

    public bool CheckIfSpaceEnemy(int x, int y, LevelData levelData, Player player, Enemy enemy)
    {
        Position wantedPosition = new Position(x, y);
        foreach (var element in levelData.Elements)
        {
            if (element.Position.Equals(wantedPosition))
            {
                return false;
            }

            if (wantedPosition.Equals(player.Position) && element is Rat)
            {
                GameAction.EnemyAttacks(enemy, player, levelData);

                return false;
            }
        }
        return true;
    }

    public enum Move
    {
        Up,
        Down,
        Left,
        Right,
    }





}


