using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Instrumon", menuName = "Instrumon/Create new Instrumon")]

public class InstrumonBase : ScriptableObject
{
    [SerializeField] string instrumonName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] InstrumonType type;

    //Instrumon base stats are created to be assigned to the monster.

    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int speed;
    [SerializeField] int currentHP;

    public string Name {
        get { return name; }
    }
    public string Description {
        get { return description; }
    }

    public Sprite FrontSprite {
        get { return frontSprite; }
    }

    public InstrumonType Type {
        get { return type; }
    }

    public int MaxHP {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int Attack {
        get { return attack; }
        set { attack = value; }
    }

    public int Speed {
        get { return speed; }
        set { speed = value; }
    }
    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value;}
    }

    

}

//Lists all possible Instrumon typings
public enum InstrumonType 
{
    String,
    Brass,
    Percussion,
    Woodwind
}