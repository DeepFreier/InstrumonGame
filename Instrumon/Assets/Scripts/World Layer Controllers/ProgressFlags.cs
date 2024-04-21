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
    private static List<Instrumon> playerparty;

    public static GameObject opponent;
    private static List<Instrumon> opponentparty;

    public static ProgressFlags Instance { get; private set; }

    

    

    private void Awake()
    {
        Instance = this;
        player = GameObject.Find("Player");
        playerparty = player.GetComponent<PlayerController>().playerparty;

        

        if (Flag == 1)
        {
            GameObject opponent = GameObject.Find("SeadockFight_NPC");
            opponentparty = opponent.GetComponent<MusicianNPC_Controller>().mnpcparty;
            
        }
        else
        {
            opponentparty = new List<Instrumon>();
        }
    }

    private void Start()
    {
        
    }

    public static List<Instrumon> ReturnPlyrPrty()
    {
        return playerparty;
    }

    public static List<Instrumon> ReturnOppPrty()
    {
        return opponentparty;
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
