using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the creation of a new asset "Move" with the type and power that we want.
[CreateAssetMenu(fileName = "Move", menuName = "Instrumon/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string moveName;
    [TextArea]
    [SerializeField] string description;
    //Creates the stats for the moves we will create assets for.
    [SerializeField] InstrumonType type;
    [SerializeField] int power;
    [SerializeField] int pp;

    public string MoveName {
        get { return moveName; }
    }

    public string Description {
        get { return description; }
    }

    public InstrumonType Type {
        get { return type; }
    }

    public int Power {
        get {return power; }
    }

    public int PP {
        get { return PP; }
    }

}

