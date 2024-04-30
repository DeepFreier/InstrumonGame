using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicianNPC_Controller : MonoBehaviour , Interactable
{
    public int MNPCID;
    public string MNPCName;
    public int MNPCLevel;


    [SerializeField]
    public List<Instrumon> mnpcparty;

    Dialogue dialog;

    [SerializeField]
    Dialogue prewin;

    [SerializeField]
    Dialogue notready;

    [SerializeField]
    Dialogue postwin;

    public static bool Dialoguedone;

    public SaveSystemMk2 saveSystem;

   
    public void Interact()
    {
        if (ProgressFlags.Flag == MNPCLevel)
        {
            Debug.Log("Path 1");
            dialog = prewin;
            Dialoguedone = false;
            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog));
            DialogueManager.Instance.OnHideDialogue += () =>
            {
                saveSystem.Save();
                ProgressFlags.updateOppParty();
                SceneManager.LoadScene(2);
            };
            
        }
        if (ProgressFlags.Flag > MNPCLevel)
        {
            Debug.Log("Path 2");
            dialog = postwin;
            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog));
        }
        if (ProgressFlags.Flag < MNPCLevel)
        {
            Debug.Log("Path 3");
            dialog = notready;
            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog));
        }
        
        

        

    }
}
