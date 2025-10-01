using System;
using static System.Console; // importing resources

// I think that my program is solid with
// SO becassue it follows Single Responsibility, with each method doing
// only one clear task, and Open/Closed, since it can be extended with new features
// without changing existing code.
// This keeps the design clean, maintainable, and easy to grow.

// Creating the app class:

public class TemperaturesComparisonApp
{
    // Main method
    public static void Main ()
    {
        int numTemps = 5; // the number of elements in the array
        int minTemp = -30;// the minimum temperature
        int maxTemp = 130;// the maximum temperature

        double[] temps = new double[numTemps]; // array for storing temps

        for (int i =0; i < numTemps; i++) // Loop for adding the values to the array:
        {
            int value; // the input
            while(true)
            {
                WriteLine("Please enter a temperature: ");
                // If the input is in the range, for instance value is more or equals than minTemp AND lower or equal
                // than Max then it adds to the array
                if (int.TryParse(ReadLine(), out value) && value >= minTemp && value <= maxTemp)
                {
                    temps[i] = value;
                    break;
                }else
                {
                    WriteLine("Out of Range temp"); // it doesn't and tells you this message
                   
                }   
            }
        }
        if (isAscending(temps) == true) // if it's ascending it displays a message
        {
            WriteLine("Getting Warmer!");

        }
        else if (IsDescending(temps) == true) // if it descending displays a message too
        {
            WriteLine("Getting cooler");

        }
        else // else it's a combination:
        {
            WriteLine("It's mix bag");

        }

        WriteLine("Temperatures you've entered: ");
        PrintTemps(temps);
        WriteLine($"\n- The average if of: {TempAverage(temps)}");
        WriteLine($"\n- The hottest temperature you've entered: {FindMaxTemp(temps)}");
        WriteLine($"\n- The coolest temperature you've entered: {FindMinTemp(temps)}");

    }

    // Method to know if the order is ascending
    public static bool isAscending (double[]temps)
    {
        for (int i =1; i< temps.Length; i++)
        {
            if (temps[i] < temps[i-1])
            {
                return false;
                
            }
        }
        return true;
    }

    //Method to know if the order is descending:
    public static bool IsDescending(double[]temps)
    {
        for (int i=1; i<temps.Length; i++)
        {
            if (temps[i] > temps[i-1])
            {
                return false;
                
            }
        }
        return true;
    }

    // Method to calculate de average:
    public static double TempAverage(double[]temps)
    {
        double average = 0;

        foreach (double temp in temps)
        {
            average += temp;
        }
        return average / temps.Length;
    }

    // What I added that is new, that the program finds which
    // temperature is the hottest and the coolest from
    // what the user wrote:

    // Method for finding the hottest:
    public static double FindMaxTemp(double[]temps)
    {
        double MaxTemp = 0;
        foreach(double temp in temps)
        {
            if(temp > MaxTemp)
            {
                MaxTemp = temp;
               
            }
        }

        return MaxTemp;
    } 

    //Method for finding the coolest:
    public static double FindMinTemp(double[]temps)
    {
        double MinTemp = 0;
        foreach (double temp in temps)
        {
            if(temp < MinTemp)
            {
                MinTemp = temp; 
            }
        }
        return MinTemp;
    }

    //Method for printing the array
    public static void PrintTemps(double[]temps)
    {
        foreach( double temp in temps)
        {
            Write($" {temp} ");
        }
    }

    
}