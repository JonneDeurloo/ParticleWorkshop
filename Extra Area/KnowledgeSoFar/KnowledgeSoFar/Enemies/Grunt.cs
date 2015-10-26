using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Grunt : EnemyAbstract
{

    // -- -- \\

    // And the data mentioned earlier could be assigned within the constructor of this class.
    // However, for a demo's sake that has been excluded.

    // -- -- \\

    // -- -- \\

    // All of the methods below have been overriden from the base class.
    // This allows us to have ouw own implementation that is specific to the jackal class.

    // This principle is the override principle : replace the implementation of a functionality (read: a method) from the base class (EnemyAbstract) within the sub-class (this class).

    // -- -- \\

    public Grunt()
    {

        // -- -- \\
        // We can reach data (and methods) from the base-class. 
        //This principle is Inheritance : one class (this class) gaining all of the member variables and functionality (read: methods) of another class (EnemyAbstract), in addition to the classes own member variables and functionality.

        // take note: You can only see public or protected variables / methods. Private variables / methods, such as modelPath in EnemyAbstract, cannot be seen by sub-classes such as this one.
        // -- -- \\

        this.health = 25;

        this.shield = false;
    }

    public override void PlayerWithin100Feet()
    {
        Console.WriteLine("If any elite goes out to investigate, go into battle stance (as in, be prepared to fire).");

        Console.WriteLine("If there are any other grunts going into battle stance, go into battle stance also.");

        Console.WriteLine("There is a ten percent chance that the grunt 'hears' the player, if that the case: go into battle stance.");

        Console.WriteLine("otherwise, keep doing what the grunt was doing.");
    }

    public override void PlayerWithin10Feet()
    {
        Console.WriteLine("Check through the pathing system whether or not it's logical that we 'know' about the player (for example: is there a wall between us?)");

        Console.WriteLine("If there is no elite nearby, run away in fear. Otherwise: go aggro.");
    }

    public override void PlayerNearlyDead()
    {
        Console.WriteLine("Throw a grenade to where the grunt expects the player to be, assuming it is logical for the grunt to know that the player is hurt.");
    }

    public override void DespairAction()
    {
        Console.WriteLine("Grap two grenades, activate them, keep them in the grunt's hands and run towards the player.");
    }

}