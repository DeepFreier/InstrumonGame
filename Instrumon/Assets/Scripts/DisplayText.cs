using System.Collections;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    // Reference to the DialogueManager
    private DialogueManager dialogueManager;

    private void Awake()
    {
        // Get reference to DialogueManager
        dialogueManager = DialogueManager.Instance;
    }

    // Display dialogue from a single string
    public void DisplayThis(string dialogText)
    {
        // Create a new Dialogue object and add the provided string as a line
        Dialogue dialog = new Dialogue();
        dialog.Lines.Add(dialogText);

        // Start the dialogue
        StartCoroutine(dialogueManager.ShowDialogue(dialog));
    }
}
