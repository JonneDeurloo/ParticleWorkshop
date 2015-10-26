using System;

public class Program
{

    // -- -- \\

    // Below is the variable that is mentioned in the document.
    // Take note that we're assigning a sub-class of EnemyAbstract to the variable.

    // -- -- \\

    static EnemyAbstract enemy = new Elite();

    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to this demo!");
        Console.WriteLine("");

        Help();

        while (true)
        {
            string line = Console.ReadLine();

            // -- -- \\

            // We're re-assigning the EnemyAbstract variable enemy real time, with any of its sub-classes.
            // This principle is polymorphism - a variable that has the type of a base class (EnemyAbstract), but it's assigned to one of its sub-classes (Grunt, Elite, Jackal, Hunter).
           
            // -- -- \\

            if (line.ToLower() == "grunt")
            {
                enemy = new Grunt();
                Console.WriteLine("You currently are a " + enemy.ToString() + ".");
            }

            if (line.ToLower() == "elite")
            {
                enemy = new Elite();
                Console.WriteLine("You currently are a " + enemy.ToString() + ".");
            }

            if (line.ToLower() == "hunter")
            {
                enemy = new Hunter();
                Console.WriteLine("You currently are a " + enemy.ToString() + ".");
            }

            if (line.ToLower() == "jackal")
            {
                enemy = new Jackal();
                Console.WriteLine("You currently are a " + enemy.ToString() + ".");
            }

            // -- -- \\

            // No matter what sub-class is chosen, these commands will always work.
            // And they will always give the results of the chosen sub-class.
            // Again, this principle is polymorphism.

            // -- -- \\

            if (line.ToLower() == "q")
                enemy.PlayerWithin100Feet();

            if (line.ToLower() == "w")
                enemy.PlayerWithin10Feet();

            if (line.ToLower() == "e")
                enemy.PlayerNearlyDead();

            if (line.ToLower() == "r")
                enemy.DespairAction();

            if (line.ToLower() == "current")
                Console.WriteLine("You currently are a " + enemy.ToString() + ".");

            if (line.ToLower() == "help")
                Help();

            Console.WriteLine("");

        }

    }

    // Help!
    private static void Help()
    {
        Console.WriteLine("You can change the ai behaviour with the following commands: ");
        Console.WriteLine("grunt");
        Console.WriteLine("elite");
        Console.WriteLine("jackal");
        Console.WriteLine("hunter");

        Console.WriteLine("You can 'make things happen' with the following commands: ");
        Console.WriteLine("Q for player within 100 feet.");
        Console.WriteLine("W for player within ten feet.");
        Console.WriteLine("E for player nearly dead.");
        Console.WriteLine("R for despair.");

        Console.WriteLine("Other commands: ");
        Console.WriteLine("current");
        Console.WriteLine("help");
    }

}