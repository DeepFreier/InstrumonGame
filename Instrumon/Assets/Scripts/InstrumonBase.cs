using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Instrumon", menuName = "Instrumon/Create new Instrumon")]

public class InstrumonBase : ScriptableObject
{
    [SerializeField]public string instrumonName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] InstrumonType type;

    //Instrumon base stats are created to be assigned to the monster.
    [SerializeField] int basemaxHP;
    [SerializeField] int baseattack;
    [SerializeField] int basespeed;
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int speed;
    [SerializeField] int currentHP;
    [SerializeField] List<LearnedMoves> learnedMoves;

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

    public int BaseMaxHP
    {
        get { return basemaxHP; }
        set { basemaxHP = value; }
    }

    public int MaxHP {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int Attack {
        get { return attack; }
        set { attack = value; }
    }

    public int BaseAttack
    {
        get { return baseattack; }
        set { baseattack = value; }
    }

    public int Speed {
        get { return speed; }
        set { speed = value; }
    }
    public int BaseSpeed
    {
        get { return basespeed; }
        set { basespeed = value; }
    }

    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value;}
    }

    public List<LearnedMoves> LearnedMoves{
        get { return learnedMoves;}
    }

}

[System.Serializable]
public class LearnedMoves {
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base {
        get { return moveBase; }
    }
    public int Level {
        get { return level; }
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