using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Labb2
{
    public static class PlayerAction
    {
        public static int MoveLeft(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpace(x - 1, y, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveRight(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpace(x + 1, y, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveUpp(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpace(x, y - 1, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveDown(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpace(x, y + 1, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static bool CheckIfSpace(int x, int y, LevelData levelData, Player player)
        {
            foreach (var element in levelData.Elements)
            {
                bool isWall = element is Wall;
                bool HasSameXPosition = element.Position.X == x;
                bool HasSameYPosition = element.Position.Y == y;
                bool HasSamePostion = HasSameXPosition && HasSameYPosition;
                if (isWall && HasSamePostion)
                {
                    return false;
                }
                if (element is Enemy enemy && HasSamePostion)
                {
                    Fight(enemy);
                    int damage = player.DiceAttack.Throw();
                    int defence = enemy.DiceDefence.Throw();
                    int dmgAfterDef = damage - defence;
                    if (dmgAfterDef > 0)
                    {
                        enemy.Hp -= dmgAfterDef;
                    }

                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"{player.Name} slog {player.DiceAttack} damage: {damage} total damage: {dmgAfterDef} i skada");
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine($"{enemy.Name} {enemy.Hp} slog {enemy.DiceDefence} och {defence}");
                    
                    if (enemy.Hp <= 0)
                    {
                        levelData.Elements.Remove(element);
                    }
                    return false;
                }


            }
            return true;
        }
        public static bool Fight(Enemy enemy)
        {

        }
    }
}


