using static System.Runtime.InteropServices.JavaScript.JSType;
public class Dice
{
    public int SidesPerDice { get; set; }
    public int NumberOfDice { get; set; }
    public int Modifier { get; set; }
    Random random = new Random();
    public Dice(int numberOfDice, int SidesPerDice, int modifier)
    {
        this.NumberOfDice = numberOfDice;
        this.SidesPerDice = SidesPerDice;
        this.Modifier = modifier;
    }
    public int Throw()
    {
        int diceOff = 1;
        int dice = NumberOfDice * (random.Next(1, SidesPerDice + diceOff));
        return dice + Modifier;
    }
    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier} ";
    }
}
