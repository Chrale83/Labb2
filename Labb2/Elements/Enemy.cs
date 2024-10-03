using System.Data;
public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public  Dice DiceAttack { get; set; }
    public  Dice DiceDefence { get; set; }
    public Enemy(int x, int y) : base(x, y)
    {
    }
    public abstract void Update();
}
