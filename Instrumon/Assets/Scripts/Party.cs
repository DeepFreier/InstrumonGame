using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Party : MonoBehaviour
{

    //Creates a list of instrumons to allow for party adjustments
    [SerializeField] PartyBase _partyBase;
    //Initializes the pokemon within the parties
    /*private void Start() {
        foreach (var instrumon in _partyBase.Instrumons) {
            instrumon.Init();
        

        }
    }*/

    

    public Party(PartyBase party)
    {
        _partyBase = party;
    }

    

    

}
