using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Party : MonoBehaviour
{
    //Creates a list of instrumons to allow for party adjustments
    [SerializeField] List<Instrumon> instrumons;
    //Initializes the pokemon within the parties
    private void Start(){
        foreach (var instrumon in instrumons){
            instrumon.Init();
        }
    }

    public Instrumon GetHealthyInstrumon(){
        return instrumons.Where(x => x.CurrentHP > 0).FirstOrDefault();
    }

}
