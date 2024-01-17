//Author: Grace Ogden Kemp
// Descripton: this will simulate 2 dice being rolled

/* Instructions: Write a .NET console application using C# that simulates the rolling of two 6-sided dice. Use an
Array to keep track of the number of times that each combination is thrown. In other words,
keep track of how many times the combination of the two simulated dice is 2, how many times
the combination is 3, and so on, all the way up through 12.
Allow the user to choose how many times the “dice” will be thrown. Then, once you have the
number of rolls, pass that number to a second class that has a method that simulates the roll of
the dice for the number of times that the user specified. That method in the second class should
return the array containing the results. In the first class, use that array to print a histogram (using
the* character) that shows the total percentage each number was rolled. Each * will represent
1% of the total rolls. */

using System; /* This line includes the System namespace, which is necessary 
               for using basic input/output functionality and other fundamental features.*/

class diceSimulatior // define the DiceSimulator class with a Main method
{
    static void Main()
    {
        // This prompts the user to enter the number of times they want to roll the dice
        Console.Write("Welcome to the Dice Roll Simulator! \nHow many times would you like to roll the dice: ");
        int numberOfRolls = int.Parse(Console.ReadLine()); // makes an integer new variable

        // create and instance of the diceRoll class
        DiceRoll diceRoll = new DiceRoll();

        // call SimulateRolls method
        int[] results = diceRoll.SimulateRolls(numberOfRolls);

        // call print histogram method
        PrintHistogram(results, numberOfRolls);

        Console.ReadLine();
    }

    static void PrintHistogram(int[] results, int numberOfRolls)
    {
        Console.WriteLine($"\nDice Roll Simulator Results \n\n(Each * represents 1% of the total number of rolls.)\nTotal Number of Rolls: {numberOfRolls}\n");

        for (int i = 2; i <= 12; i++) // loops through possible dice totals
        {
            // calculate percentage
            double percentage = ((double)results[i] / numberOfRolls) * 100;

            // print the *s
            Console.WriteLine($"{i}: {new string('*', (int)Math.Round(percentage))} {Math.Round(percentage)}%");
        }
        Console.WriteLine("\nThank you for playing! Goodbye!");
    }
}

class DiceRoll
{
    private Random random = new Random();

    public int[] SimulateRolls(int numberOfRolls)
    {
        int[] results = new int[13]; // Index 0 is not used

        for (int i = 0; i < numberOfRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int total = dice1 + dice2;

            results[total]++;
        }
        return results;
    }
}