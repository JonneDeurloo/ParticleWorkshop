using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class EnemyAbstract
{
    
    // -- -- \\

    // A class such as this would also contain a lot of extra data, such as the weapon it carries, what weapons it can carry...
    // However, for a demo's sake this has been excluded.

    // -- -- \\

    public float health;

    public bool shield;
    public float shieldValue;

    protected string aiCurrentBehaviour;

    private string modelPath;

    protected int pathingSize;

    // -- -- \\

    // The functions below are abstract. This means that they contain no implementation within the abstract class.
    // Any class that tries to inherit from this class, will be required to give it an implementation (read: override it).
    // This means that grunts can reply differently in certain situations, then for example, elites.

    // -- -- \\

    public abstract void PlayerWithin100Feet();

    public abstract void PlayerWithin10Feet();

    public abstract void PlayerNearlyDead();

    public abstract void DespairAction();   

}