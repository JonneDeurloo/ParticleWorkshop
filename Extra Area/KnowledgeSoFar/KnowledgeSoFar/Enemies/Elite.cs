using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Elite : EnemyAbstract
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

    public Elite()
    {

        // -- -- \\
        // We can reach data (and methods) from the base-class. 
        //This principle is Inheritance : one class (this class) gaining all of the member variables and functionality (read: methods) of another class (EnemyAbstract), in addition to the classes own member variables and functionality.

        // take note: You can only see public or protected variables / methods. Private variables / methods, such as modelPath in EnemyAbstract, cannot be seen by sub-classes such as this one.
        // -- -- \\

        this.health = 100;

        this.shield = true;
        this.shieldValue = 225;
    }

    public override void PlayerWithin100Feet()
    {
        Console.WriteLine("Check through the pathing system whether or not it's logical that we 'know' about the player (for example: is there a wall between us?)");

        Console.WriteLine("If it's logical, the elite will go out to investigate. Otherwise, it will keep doing whatever it was doing.");
    }

    public override void PlayerWithin10Feet()
    {
        Console.WriteLine("Check through the pathing system whether or not it's logical that we 'know' about the player (for example: is there a wall between us?)");

        Console.WriteLine("Go aggro. Attack the player. Melee him if he or she gets too close.");
    }

    public override void PlayerNearlyDead()
    {
        Console.WriteLine("If we may have a clue where the player is, then go after him or her. Hunt him or her down.");
    }

    public override void DespairAction()
    {
        Console.WriteLine("Go into frenzy mode, become berserk. Run towards the player shooting while trying to melee him or her.");
    }

}