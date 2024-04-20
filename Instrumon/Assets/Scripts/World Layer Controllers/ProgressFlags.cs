using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ProgressFlags : MonoBehaviour
{
    public static int Flag = 1;

    [SerializeField]
    public static GameObject player;

    public static GameObject opponent;

    public static ProgressFlags Instance { get; private set; }

    

    

    private void Awake()
    {
        Instance = this;
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        
    }

    public static List<Instrumon> returnPlyrPrty()
    {
        List<Instrumon> PlayerParty = player.GetComponent<PlayerController>().playerparty;
        return PlayerParty;
    }

    public static List<Instrumon> returnOppPrty()
    {
        List<Instrumon> OppParty;

        if(Flag == 1)
        {
            GameObject opponent = GameObject.Find("SeadockFight_NPC");
            OppParty = opponent.GetComponent<NPCController>().npcparty;
            return OppParty;
        }
        else
        {
            return new List<Instrumon>();
        }
    }





    public static void UpdateFlag(int newflag)
    {
        ProgressFlags.Flag = newflag;
        player.GetComponent<PlayerController>().playerlevel = newflag;
        player.GetComponent<PlayerController>().UpdateParty();
        Debug.Log("Flag Updated");

    }

   


    public static int GetFlag()
    {
        return ProgressFlags.Flag;
    }
}
