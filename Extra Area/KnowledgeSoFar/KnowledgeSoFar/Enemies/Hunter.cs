using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Hunter : EnemyAbstract
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

    public Hunter()
    {

        // -- -- \\
        // We can reach data (and methods) from the base-class. 
        //This principle is Inheritance : one class (this class) gaining all of the member variables and functionality (read: methods) of another class (EnemyAbstract), in addition to the classes own member variables and functionality.

        // take note: You can only see public or protected variables / methods. Private variables / methods, such as modelPath in EnemyAbstract, cannot be seen by sub-classes such as this one.
        // -- -- \\

        this.health = 1200;

        this.shield = false;
    }

    public override void PlayerWithin100Feet()
    {
        Console.WriteLine("Face towards the sound. Do nothing else, until the hunter happens to see the player, then start shooting.");
    }

    public override void PlayerWithin10Feet()
    {
        Console.WriteLine("Check through the pathing system whether or not it's logical that we 'know' about the player (for example: is there a wall between us?)");

        Console.WriteLine("Hit the player, and keep hitting.");
    }

    public override void PlayerNearlyDead()
    {
        Console.WriteLine("Keep shooting towards the last known position of the player. Assuming this is logical to do, of course.");
    }

    public override void DespairAction()
    {
        Console.WriteLine("Go into frenzy. Run towards the player and try to melee him. Nothing else.");
    }

}