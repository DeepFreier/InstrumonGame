using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Flag indicating whether the game is paused or not
    public bool IsPaused { get; private set; }

    // References to various UI panels and buttons
    public GameObject pauseMenu;
    public GameObject instrumonPanel;
    public GameObject optionsPanel;
    public GameObject playerPanel;

    public Button instrumonButton;
    public Button optionsButton;
    public Button playerButton;
    public Button saveButton;
    public Button quitButton;

    // References to other game objects and components
    public PlayerController playerController;
    public Animator animator;

    // Reference to GameController to access the GameState
    public GameController gameController;

    private void Awake()
    {
        TogglePauseMenu(false);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Check whether the pause menu is currently active
        bool isActive = pauseMenu.activeSelf;

        // Toggle the pause menu state when the Escape key is pressed, only if GameState is FreeRoam
        if (Input.GetKeyDown(KeyCode.Escape) && gameController.GetGameState() == GameState.FreeRoam)
        {
            TogglePauseMenu(!isActive);
        }

        // Disable buttons when any panel is active
        bool anyPanelActive = instrumonPanel.activeSelf || optionsPanel.activeSelf || playerPanel.activeSelf;
        DisableButtons(anyPanelActive);

        // Ignore player input when the game is paused
        if (IsPaused)
        {
            playerController.IgnoreInput();
        }
        else
        {
            playerController.AllowInput();
        }
        
    }

    // Method to toggle the pause menu
    void TogglePauseMenu(bool pause)
    {
        pauseMenu.SetActive(pause);
        IsPaused = pause;

        // Pause or resume the game and related components accordingly
        if (pause)
        {
            Time.timeScale = 0f;
            playerController.enabled = false;
            animator.enabled = false;
        }
        else
        {
            Time.timeScale = 1f;  // Resume the game
            playerController.enabled = true;  // Enable player movement
            animator.enabled = true;  // Enable animator
        }

        // Close all panels when pausing or resuming the game
        CloseAllPanels();
    }

    // Method to disable buttons when any panel is active
    void DisableButtons(bool disable)
    {
        instrumonButton.enabled = !disable;
        optionsButton.enabled = !disable;
        playerButton.enabled = !disable;
        saveButton.enabled = !disable;
        quitButton.enabled = !disable;
    }

    // Method to close all panels
    void CloseAllPanels()
    {
        instrumonPanel.SetActive(false);
        optionsPanel.SetActive(false);
        playerPanel.SetActive(false);
    }
}
