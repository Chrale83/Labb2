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
        public static int MoveLeft(int x, int y, LevelData levelData)
        {
            if (CheckIfSpace(x - 1, y, levelData))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveRight(int x,int y, LevelData levelData)
        {
            if (CheckIfSpace(x + 1, y, levelData))
            {
                return 1;
            }
            return 0;
        }
        public static int MoveUpp(int x,int y,LevelData levelData)
        {
            if (CheckIfSpace(x , y - 1, levelData))
            {
                return 1;
            }
            return 0;
        }

        public static int MoveDown(int x, int y, LevelData levelData)
        {
            if (CheckIfSpace(x, y + 1, levelData))
            {
                return 1;
            }
            return 0;
        }

            
        public static bool CheckIfSpace(int x, int y, LevelData levelData)
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

                
                if (element is Rat && HasSamePostion)
                {
                    Rat rat = (Rat)element;
                    rat.Hp -= 5;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(rat.Hp);
                    if (rat.Hp <= 0)
                    {
                        levelData.Elements.Remove(element);
                    }
                    return false;
                }
            }
            return true;
        }

    }
}
            
                    
        
        

