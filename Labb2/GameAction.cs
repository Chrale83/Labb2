
using System.Numerics;
using System;
using System.Reflection.PortableExecutable;

namespace Labb2
{
    public static class GameAction
    {

        public static int MoveLeft(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x - 1, y, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveRight(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x + 1, y, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveUpp(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y - 1, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveDown(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y + 1, levelData, player))
            {
                return 1;
            }
            return 0;
        }
        public static bool CheckIfSpacePlayer(int x, int y, LevelData levelData, Player player)
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
                    return PlayerAttack(enemy, player, levelData);
                }
            }
            return true;
        }
        public static bool PlayerAttack(Enemy enemy, Player player, LevelData levelData)
        {
            int damage = player.DiceAttack.Throw();
            int defence = enemy.DiceDefence.Throw();
            int playerTotalDmg = damage - defence;
            if (playerTotalDmg > 0)
            {
                enemy.Hp -= playerTotalDmg;
            }
            damage = enemy.DiceAttack.Throw();
            defence = player.DiceDefence.Throw();
            int enemyTotalDmg = damage - defence;
            if (enemyTotalDmg > 0)
            {
                player.Hp -= enemyTotalDmg;
            }
            ClearFightStat();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{player.Name} slog {player.DiceAttack} och gjorde totalt {playerTotalDmg} i skada");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{enemy.Name} slog {enemy.DiceDefence} gjorde totalt {enemyTotalDmg} i skada");
            Console.ResetColor();
            if (enemy.Hp <= 0)
            {
                
                return true;
            }
            return false;
        }




        

        public static bool EnemyAttack(Enemy enemy, Player player, LevelData levelData)
        {
            int damage = enemy.DiceAttack.Throw();
            int defence = player.DiceDefence.Throw();
            int totalDmgAfterDef = damage - defence;
            if (totalDmgAfterDef > 0)
            {
                player.Hp -= totalDmgAfterDef;
            }
            damage = player.DiceAttack.Throw();
            defence = enemy.DiceDefence.Throw();
            totalDmgAfterDef = damage - defence;
            if (totalDmgAfterDef > 0)
            {
                enemy.Hp -= totalDmgAfterDef;
            }
            ClearFightStat();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{enemy.Name} slog {enemy.DiceAttack} och gjorde totalt {totalDmgAfterDef} i skada");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{player.Name} slog {player.DiceDefence} gjorde totalt {totalDmgAfterDef} i skada");
            Console.ResetColor();

            if (enemy.Hp <= 0)
            {
                
                return true;

            }
            return false;
        }

        
        public static void ClearFightStat()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 2);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
