using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialogue, Battle}


public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    

    GameState state;

    private void Start()
    {
        //Grabs the Instance var in DialogueManager and changes game state when 
        //those actions are invoked
        DialogueManager.Instance.OnShowDialogue += () =>
        {
            state = GameState.Dialogue;
        };
        DialogueManager.Instance.OnHideDialogue += () =>
        {
            if (state == GameState.Dialogue)
            {
                state = GameState.FreeRoam;
            }
        };
    }

    //Checks when these gamestates are on
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }   
            else if(state == GameState.Dialogue)
            {
                DialogueManager.Instance.HandleUpdate();
            }   
            else if (state == GameState.Battle)
            {

            }
    }
    public GameState GetGameState()
    {
        return state;
    }
}
