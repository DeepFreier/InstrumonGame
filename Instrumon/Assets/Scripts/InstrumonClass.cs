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
    [SerializeField] InstrumonType type1;

    //Instrumon stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int speed;
}

public enum InstrumonType 
{
    String,
    Brass,
    Percussion,
    Woodwind
}