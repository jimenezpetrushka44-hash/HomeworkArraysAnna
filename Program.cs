using System;
using static System.Console;


public class RePrice
{
    public int Night { get; }
    public int MaxNight { get; }
    public double Rate { get; }

    public RePrice(int night, int max, int rate)
    {
        Night = night;
        MaxNight = max;
        Rate = rate;
    }

    public bool AppliesTo(int nights)
    {
        return nights >= Night && nights <= MaxNight;
    }

    public double CalcPrice(int nights)
    {
        return Rate * nights;
    }
      
};

public class ResortPricesApp
{
    int choice;
    public static void Main()
    {
        RePrice[] reprice = new RePrice[]
        {
            new RePrice(1, 2, 200),
            new RePrice(3, 4, 180),
            new RePrice(5, 7, 160),
            new RePrice(8, int.MaxValue, 145)
        };

        WriteLine("Welcome to The Carefree Resort program, here you will see our prices per night: ");
        WriteLine();
        WriteLine("--- THE CAREFREE PRICES:");
        PrintPrices(reprice);

        WriteLine("How many night you will be staying?: ");
        int choice = int.Parse(ReadLine());

        RePrice selected = FindRate(reprice, choice);

        
        WriteLine($"\nPrice per night: ${selected.Rate}");
        WriteLine($"Total charge for {choice} nights: ${selected.CalcPrice(choice)}");
    }

    public static void PrintPrices(RePrice[] reprice)
    {
        foreach (RePrice reprices in reprice)
        {
            WriteLine($"- Nights: {reprices.Night} to {reprices.MaxNight} - Price per night: ${reprices.Rate}");
        }
    }

    public static RePrice FindRate(RePrice[] prices, int nights)
    {
        foreach (var p in prices)
        {
            if (p.AppliesTo(nights))
            {
                return p;
            }
        }
        throw new Exception("INVALID -- no matching range");
    }
}
