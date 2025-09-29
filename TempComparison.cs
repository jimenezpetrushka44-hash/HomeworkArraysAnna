using System;
using static System.Console;

public class TemperaturesComparisonApp
{
    public static void Main ()
    {
        int numTemps = 5;
        int minTemp = -30;
        int maxTemp = 130;

        int[] temps = new int[numTemps];

        for (int i =0; i < numTemps; i++)
        {
            int value;
            while(true)
            {
                WriteLine("Please enter a temperature: ");
                if (int.TryParse(ReadLine(), out value) && value >= minTemp && value <= maxTemp)
                {
                    temps[i] = value;
                    break;
                }else
                {
                    WriteLine("Out of Range temp");
                   
                }   
            }
        }
        if (isAscending(temps) == true)
        {
            WriteLine("Getting Warmer!");

        }
        else if (IsDescending(temps) == true)
        {
            WriteLine("Getting cooler");

        }
        else
        {
            WriteLine("It's mix bag");

        }

        WriteLine("Temperatures you've entered: ");
        PrintTemps(temps);
        WriteLine($"\nThe average if of: {TempAverage(temps)}");

    }

    public static bool isAscending (int[]temps)
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

    public static bool IsDescending(int[]temps)
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

    public static double TempAverage(int[]temps)
    {
        double average = 0;

        foreach (int temp in temps)
        {
            average += temp;
        }
        return average / temps.Length;
    }

    public static void PrintTemps(int[]temps)
    {
        foreach( int temp in temps)
        {
            Write($" {temp} ");
        }
    }

    
}