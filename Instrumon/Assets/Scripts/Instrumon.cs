using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
[System.Serializable]
public class Instrumon
{
    [SerializeField] InstrumonBase _base;

    [SerializeField] int InstrumonLevel;

    [SerializeField] List<Moves> moves;

     public int level;


    //Takes note of the Instrumon's stats, current level, and current HP.
    public InstrumonBase Base {
        get { return _base; }
    }
    public int Level {
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

    public void LevelSet(int lvl)
    {
        level = lvl;
    }

    public List<Move> Moves { get; set; }
    public Instrumon(InstrumonBase iBase){
        _base = iBase;
        Moves = new List<Move>();
        foreach (var move in _base.Moves){
            if (move.Level <= level)
                Moves.Add(new Move(move.Base));
        }
    } 

//Formulas for increasing stats as an Instrumon levels up.
    public int MaxHP {
        get { return Mathf.FloorToInt(_base.MaxHP+(((_base.MaxHP * level) / 100f) + (level * 10))); }
    }
    public int Attack {
        get { return Mathf.FloorToInt(_base.Attack+(((_base.Attack * level) / 100f) +(level * 5))); }
    }
    public int Speed {
        get { return Mathf.FloorToInt(_base.Speed+(((_base.Speed * level) / 100f) +(level * 5))); }
    }
}
