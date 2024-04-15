using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    //This is here to placehold in case we ever want to implement PP as a changeable variable.
    public MoveBase Base { get; set; }
    public int PP { get; set; }

    public Move(MoveBase iBase){
        Base = iBase;
        PP = iBase.PP;
    }
}
