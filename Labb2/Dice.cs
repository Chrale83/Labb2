﻿using static System.Runtime.InteropServices.JavaScript.JSType;
public class Dice
{

    public int SidesPerDice { get; set; }
    public int NumberOfDice { get; set; }
    public int Modifier { get; set; }
    public int TotalValue { get; set; }
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
        int dice = NumberOfDice * (random.Next(1, SidesPerDice + diceOff) + Modifier);
        return dice;
    }
    
    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier} ";
    }

}
//Skapa en klass “Dice” med en konstruktor som tar 3 parametrar: numberOfDice, sidesPerDice och Modifier. 
//    Genom att skapa nya instans av denna kommer man kunna skapa olika uppsättningar av tärningar t.ex “3d6+2”, 
//    d.v.s slag med 3 stycken 6-sidiga tärningar, där man tar resultatet och sedan plussar på 2, för att få en total poäng.

//Dice-objekt ska ha en publik Throw() metod som returnerar ett heltal med den poäng man får när man slår med 
//    tärningarna enligt objektets konfiguration. Varje anrop motsvarar alltså ett nytt kast med tärningarna.

//Gör även en override av Dice.ToString(), så att man när man skriver ut ett Dice-objekt får en sträng som 
//beskriver objektets konfiguration. t.ex: “3d6 + 2”.


//public int ThrowDice()
//{
//    int dice = random.Next(1, 7);
//    return dice;
//}
//public int ThrowMultipleDice(int n)
//{
//    int multiDice = n * ThrowDice();
//    return multiDice;
//}