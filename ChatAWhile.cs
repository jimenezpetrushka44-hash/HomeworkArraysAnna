// Importing resources:

using System;
using static System.Console;

// I think that my program is SOLID because it follows Single Responsibility: 
// each method has only one task (price, tax, printing, search). 
// With the new tax feature added, it still respects Open/Closed since 
// the logic was extended without modifying the original code structure.


// Creating chat object:
public class Chat
{
    // Each Chat has an areacode and a Rate, these are my attributes:
    public int AreaCode { get; set; }
    public double Rate { get; set; }

    // Constructor setting to create new chats
    public Chat(int areacode, double rate)
    {
        AreaCode = areacode;
        Rate = rate;
    }

    // Method to check if the given areacode matches the areacode of the chat
    public bool AppliesTo(int areacode)
    {
        return areacode == AreaCode;
    }

    // Method for calculating the price:
    public double CalcPrice(int minutes)
    {
        return Rate * minutes;
    }

    // I added price with taxes (THIS IS WHAT I ADD THAT IS NEW:): 

    // This method is for finding the tax quantity that will be added to the actual price
    public double FindTax(int minutes)
    {
        return CalcPrice(minutes) * 0.15;
        
    }

    // Method for calculating the price with tax:
    public double PricewithTax(int minutes)
    {
        return CalcPrice(minutes) + FindTax(minutes);
    }

   
};

// Creating the app class:

public class ChatAWhileApp
{
    int minutes; // input the minutes the user will be chatting

    // Main method:
    public static void Main()
    {
        //Creating the array of objects:
        Chat[] chat = new Chat[]
        {
            new Chat (262, 0.07),
            new Chat (414, 0.10),
            new Chat (628, 0.05),
            new Chat (715, 0.16),
            new Chat (815, 0.24),
            new Chat (920, 0.14)
        };

        // Asking for input:
        WriteLine("Welcome to the Chat A While program, here you will see our prices per minute: ");
        WriteLine();
        WriteLine("--- THE Chat A While PRICES:");
        PrintPrices(chat);

        WriteLine("For which area code?: ");
        int areacode = int.Parse(ReadLine()); // areacode input


        Chat selected = FindRate(chat, areacode); // Finds the object the user is asking

        WriteLine($"\nPrice per minute for {selected.AreaCode} is : ${selected.Rate}");// displays price per minute for the selected area
        WriteLine("How many minutes?");
        int minutes = int.Parse(ReadLine());   // recieves input  
        WriteLine($"Total Charge: ${selected.CalcPrice(minutes):F2}");  // prints total charge without taxes
        WriteLine($"Price with tax: ${selected.PricewithTax(minutes):F2}"); // with taxes

    }

    // method that prints the Array:
    public static void PrintPrices(Chat[]chat)
    {
        foreach (Chat c in chat)
        {
            WriteLine($"- Area Codes: {c.AreaCode} - Price per minute: {c.Rate}");
        }
    }

    //Method that looks for the rate of the given areacode:
    public static Chat FindRate(Chat[]chat, int areacode)
    {
        foreach (Chat c in chat)
        {
            if (c.AppliesTo(areacode))
            {
                return c;
            }
        }
        throw new Exception("There's no areacode for that");
    }
}