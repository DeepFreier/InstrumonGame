using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public GameObject instrumonPanel;
    public GameObject optionsPanel;
    public GameObject playerPanel;
    public Button instrumonButton;
    public Button optionsButton;
    public Button playerButton;
    public Button saveButton;
    public Button quitButton;

    public PlayerController playerController;

    public Animator animator;

    void Update()
    {
        // Check whether it's active or inactive 
        bool isActive = pauseMenu.activeSelf;

        // Reverse the active state every time escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!isActive);
            isPaused = !isActive;

            if (isPaused)
            {
                // Pause the game including player movement
                Time.timeScale = 0f;
                playerController.enabled = false;
                animator.enabled = false;
            }
            else
            {
                // Resume the game including player movement
                Time.timeScale = 1f;
                playerController.enabled = true;
                animator.enabled = true;
            }

            // Ensure other panels are closed when pausing or resuming the game
            instrumonPanel.SetActive(false);
            optionsPanel.SetActive(false);
            playerPanel.SetActive(false);
        }

        // Disable buttons when any panel is active
        bool anyPanelActive = instrumonPanel.activeSelf || optionsPanel.activeSelf || playerPanel.activeSelf;
        instrumonButton.enabled = !anyPanelActive;
        optionsButton.enabled = !anyPanelActive;
        playerButton.enabled = !anyPanelActive;
        saveButton.enabled = !anyPanelActive;
        quitButton.enabled = !anyPanelActive;
    }
}
