using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubNPC_Controller : MonoBehaviour, Interactable
{
    public int CNPCID;
    public string CNPCName;


    [SerializeField] Dialogue dialog;
    

    GameObject player;



    //Calls the Dialogue when the player interacts with the NPC
    public void Interact()
    {
        player = GameObject.Find("Player");
        List<Instrumon> playerparty = player.GetComponent<PlayerController>().playerparty;
        //Debug.Log("You will start a battle!");
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog));
        foreach (var instrumon in playerparty)
        {
            instrumon.Base.CurrentHP = instrumon.Base.MaxHP;
            Debug.Log(instrumon.Base.CurrentHP);
        }
        
    }
}
