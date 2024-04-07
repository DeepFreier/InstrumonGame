using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Instrumon
{
    //Takes note of the Instrumon's stats, current level, and current HP.
    InstrumonBase _base;
    int level;
    public int HP { get; set; }

    public Instrumon(InstrumonBase iBase, int iLevel)
    {
        _base = iBase;
        level = iLevel;
        HP = _base.MaxHP;
    }
//Formulas for increasing stats as an Instrumon levels up.
    public int MaxHP {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) +10; }
    }
    public int Attack {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) +5; }
    }
    public int Speed {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) +5; }
    }
}
