using Labb2;
using System.Data;
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





}


