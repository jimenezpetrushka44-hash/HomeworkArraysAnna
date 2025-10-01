using System;
using static System.Console;

// My program is SO because it follows Single Responsibility: 
// each method does only one task (check range, price, tax, printing, search). 
// With the new tax feature added, it also respects Open/Closed, since 
// the logic was extended without modifying the original structure


// Creating the RePrice object:
public class RePrice
{
    // Attributes for the object:
    public int Night { get; }
    public int MaxNight { get; }
    public double Rate { get; }

    // Constructor for assigning:
    public RePrice(int night, int max, int rate)
    {
        Night = night;
        MaxNight = max;
        Rate = rate;
    }

    // Method for checking if it the nights fits within the price range
    public bool AppliesTo(int nights)
    {
        return nights >= Night && nights <= MaxNight;
    }

    // Method for calculating the price
    public double CalcPrice(int nights)
    {
        return Rate * nights;
    }

    // Method for finding tax (THIS IS NEW):
    public double FindTax(int nights)
    {
        return CalcPrice(nights) * 0.15;
    }
    
    // Method for calculating the price with taxes:
    public double PriceWithTax(int nights)
    {
        return CalcPrice(nights) + FindTax(nights);
    }
};

// App class:
public class ResortPricesApp
{
    int choice; // user's input

    // Main method
    public static void Main()
    {
        // Array of objects:
        RePrice[] reprice = new RePrice[]
        {
            new RePrice(1, 2, 200),
            new RePrice(3, 4, 180),
            new RePrice(5, 7, 160),
            new RePrice(8, int.MaxValue, 145)
        };
        // Gathering input
        WriteLine("Welcome to The Carefree Resort program, here you will see our prices per night: ");
        WriteLine();
        WriteLine("--- THE CAREFREE PRICES:");
        PrintPrices(reprice);

        WriteLine("How many night you will be staying?: ");
        int choice = int.Parse(ReadLine()); // reading input

        RePrice selected = FindRate(reprice, choice); // finds the corrext rate for the user nights

        // Printing totals: 
        WriteLine($"\nPrice per night: ${selected.Rate}"); //Printing the rate
        WriteLine($"Total charge for {choice} nights: ${selected.CalcPrice(choice)}"); // Price without tax
        WriteLine($"Total with taxes: ${selected.PriceWithTax(choice)}");// Price with taxes
    }

    // method for printing the array:
    public static void PrintPrices(RePrice[] reprice)
    {
        foreach (RePrice reprices in reprice)
        {
            WriteLine($"- Nights: {reprices.Night} to {reprices.MaxNight} - Price per night: ${reprices.Rate}");
        }
    }

    // method for finding the rate corresponding to the night quantity
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
