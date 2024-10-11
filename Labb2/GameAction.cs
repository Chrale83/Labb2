namespace Labb2
{
    public static class GameAction
    {
        const int cantMoveToPosition = 0;
        const int moveToPosition = 1;
        const int adjecentPosition = 1;
        public static int MoveLeft(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x - adjecentPosition, y, levelData, player))
            {
                return moveToPosition;
            }
            return cantMoveToPosition;
        }
        public static int MoveRight(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x + adjecentPosition, y, levelData, player))
            {
                return moveToPosition;
            }
            return cantMoveToPosition;
        }
        public static int MoveUpp(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y - adjecentPosition, levelData, player))
            {
                return moveToPosition;
            }
            return cantMoveToPosition;
        }
        public static int MoveDown(int x, int y, LevelData levelData, Player player)
        {
            if (CheckIfSpacePlayer(x, y + adjecentPosition, levelData, player))
            {
                return moveToPosition;
            }
            return cantMoveToPosition;
        }
        public static bool CheckIfSpacePlayer(int x, int y, LevelData levelData, Player player)
        {
            foreach (var element in levelData.Elements)
            {

                bool HasSameXPosition = element.Position.X == x;
                bool HasSameYPosition = element.Position.Y == y;
                bool HasSamePostion = HasSameXPosition && HasSameYPosition;
                if (element is Wall && HasSamePostion)
                {
                    return false;
                }
                else if (element is Enemy enemy && HasSamePostion)
                {

                    return PlayerAttacks(enemy, player);

                }
            }
            return true;
        }
        public static bool PlayerAttacks(Enemy enemy, Player player) //<------------ Slå ihop denna metod med EnemyAttacks metoden !!!!!!!
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

            ClearStatusWindows(1, 2);
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

            ClearStatusWindows(1, 2);
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
                return "Slightly wounded";
            }
            else
            {
                return "Severly damaged";
            }
        }
        public static void ClearStatusWindows(int line1, int line2)
        {
            Console.SetCursorPosition(0, line1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line2);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        public static void ClearStatInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
    }
}
