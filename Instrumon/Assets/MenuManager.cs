using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the in-game menu functionality including pausing the game, displaying various panels, and handling button interactions.
/// </summary>
public class MenuManager : MonoBehaviour
{
    // Flag indicating whether the game is paused or not
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

    // Reference to the player controller script
    public PlayerController playerController;

    // Reference to the animator component
    public Animator animator;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Check whether the pause menu is currently active
        bool isActive = pauseMenu.activeSelf;

        // Toggle the pause menu state when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!isActive);
            isPaused = !isActive;

            // Pause or resume the game and related components accordingly
            if (isPaused)
            {
                Time.timeScale = 0f;  // Pause the game
                playerController.enabled = false;  // Disable player movement
                animator.enabled = false;  // Disable animator
            }
            else
            {
                Time.timeScale = 1f;  // Resume the game
                playerController.enabled = true;  // Enable player movement
                animator.enabled = true;  // Enable animator
            }

            // Close other panels when pausing or resuming the game
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
