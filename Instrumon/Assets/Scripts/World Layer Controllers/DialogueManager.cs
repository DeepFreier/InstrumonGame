using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialogue;
    public event Action OnHideDialogue;

    public static DialogueManager Instance { get; private set; }

    //Sets the Instance var to whatever is invoking this class at that point
    private void Awake()
    {
        Instance = this;
    }

    //Vars for the Dialogue
    Dialogue dialogue;
    int currentLine = 0;
    bool isTyping;

    
    //Types the lines out for the dialogue box instead of throwing them all in there.
    public IEnumerator ShowDialogue(Dialogue dialogue)
    {
        yield return new WaitForEndOfFrame();
        //Invokes the action in Above
        OnShowDialogue?.Invoke();

        this.dialogue = dialogue;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));

    }

    //Handles the update so this code only runs when the game is in
    //the right game state
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            //Changes currentLine and then goes through the lines in the dialogue
            ++currentLine;
            if (currentLine < dialogue.Lines.Count) 
            {
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine]));
            }
            else
            {
                //Ends the Dialogue when out of lines and changes gamestate
                //by invoking the right action
                dialogueBox.SetActive(false);
                currentLine = 0;
                OnHideDialogue?.Invoke();
            }
            
        }
    }

    //Types dialogue out 1 letter at a time like in old games.
    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }

    /* Function to set the letters per second value
    public void SetLettersPerSecond(int newValue)
    {
        lettersPerSecond = newValue;
        // Save the new value using PlayerPrefs
        PlayerPrefs.SetInt("LettersPerSecond", newValue);
        PlayerPrefs.Save();
    } */
}
