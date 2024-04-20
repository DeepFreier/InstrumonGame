using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    public int NPCID;
    public string NPCName;


    [SerializeField] Dialogue dialog;

    [SerializeField]
    public List<Instrumon> npcparty;

    //Calls the Dialogue when the player interacts with the NPC
    public void Interact()
    {
        //Debug.Log("You will start a battle!");
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog));
    }

}
