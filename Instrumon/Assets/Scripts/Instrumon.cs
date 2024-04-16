using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[System.Serializable]
public class Instrumon
{
    [SerializeField] InstrumonBase _base;
    [SerializeField] int level;

    //Takes note of the Instrumon's stats, current level, and current HP.
    public InstrumonBase Base {
        get { return _base; }
    }
    public int Level{
        get { return level; }
    }
    public int CurrentHP { get; set; }

    public int IDValue {
        get { return IDValue; }
    }

    public void Init()
    {
        CurrentHP = _base.MaxHP;
    }

    public List<Move> Moves { get; set; }
    public Instrumon(InstrumonBase iBase){
        _base = iBase;
        Moves = new List<Move>();
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