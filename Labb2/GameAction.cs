using System.Numerics;
using System;
using System.Reflection.PortableExecutable;
namespace Labb2
{
    public static class GameAction
    {
        const int dontMoveToPosition = 0;
        const int moveToPosition = 1;
        const int adjecentPosition = 1;
        public static int MoveLeft(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x - adjecentPosition, y, levelData, player))
            {
                return moveToPosition;
            }
            return dontMoveToPosition;
        }
        public static int MoveRight(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x + adjecentPosition, y, levelData, player))
            {
                return moveToPosition;
            }
            return dontMoveToPosition;
        }
        public static int MoveUpp(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y - adjecentPosition, levelData, player))
            {
                return moveToPosition;
            }
            return dontMoveToPosition;
        }
        public static int MoveDown(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y + adjecentPosition, levelData, player))
            {
                return moveToPosition;
            }
            return dontMoveToPosition;
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
                    return PlayerAttacks(enemy, player, levelData);
                }
            }
            return true;
        }
        public static bool PlayerAttacks(Enemy enemy, Player player, LevelData levelData)
        {
            int playerDmg = player.DiceAttack.Throw();
            int enemyDef = enemy.DiceDefence.Throw();
            int playerTotalDmg = playerDmg - enemyDef;
            if (playerTotalDmg > 0)
            {
                enemy.Hp -= playerTotalDmg;
            }
            int enemyDmg = enemy.DiceAttack.Throw();
            int playerDef = player.DiceDefence.Throw();
            int enemyTotalDmg = enemyDmg - playerDef;
            if (enemyTotalDmg > 0)
            {
                player.Hp -= enemyTotalDmg;
            }
            ClearFightStat();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{player.Name} (ATK: {player.DiceAttack}=> {playerDmg}) attacked the {enemy.Name} (DEF: {enemy.DiceDefence} => {enemyDef}) {FightStatusInText(playerTotalDmg)}");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{enemy.Name} (ATK: {enemy.DiceAttack}=> {enemyDmg}) attacked {player.Name} (DEF: {player.DiceDefence} => {playerDef}) {FightStatusInText(enemyTotalDmg)}");
            Console.ResetColor();
            if (enemy.Hp <= 0)
            {
                return true;
            }
            return false;
        }
        public static bool EnemyAttacks(Enemy enemy, Player player, LevelData levelData)
        {
            int enemyDmg = enemy.DiceAttack.Throw();
            int playerDef = player.DiceDefence.Throw();
            int enemyTotalDmg = enemyDmg - playerDef;
            if (enemyTotalDmg > 0)
            {
                player.Hp -= enemyTotalDmg;
            }
            int playerDmg = player.DiceAttack.Throw();
            int enemyDef = enemy.DiceDefence.Throw();
            int playerTotalDmg = playerDmg - enemyDef;
            if (playerTotalDmg > 0)
            {
                enemy.Hp -= playerTotalDmg;
            }
            ClearFightStat();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{enemy.Name} (ATK: {enemy.DiceAttack}=> {enemyDmg}) attacked {player.Name} (DEF: {player.DiceDefence} => {playerDef}) {FightStatusInText(enemyTotalDmg)}");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{player.Name} (ATK: {player.DiceAttack}=> {playerDmg}) attacked the {enemy.Name} (DEF: {enemy.DiceDefence} => {enemyDef}) {FightStatusInText(playerTotalDmg)} ");

            Console.ResetColor();
            if (enemy.Hp <= 0)
            {
                return true;
            }
            return false;
        }

        public static string FightStatusInText(int damage)
        {
            if (damage <= 0)
            {
                return "No damage done";
            }
            else if (damage <= 5)
            {
                return "slightly wounded the";
            }
            else  
            {
                return " severly damaged the ";
            }

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
