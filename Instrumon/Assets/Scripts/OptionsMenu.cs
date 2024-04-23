using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;

    public Slider textSpeedSlider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Update slider values when the game starts
        UpdateSliderValues();
    }

    // Called when the options menu is opened
    public void OnOptionsMenuOpen()
    {
        // Update slider values when the options menu is opened
        UpdateSliderValues();
    }

    // Update slider values based on saved settings
    private void UpdateSliderValues()
    {
        // Set text speed slider value based on saved setting
        textSpeedSlider.value = PlayerPrefs.GetInt("TextSpeed", 40);
    }

    // Called when the text speed slider value changes
    public void OnTextSpeedChanged()
    {
        // Save the new text speed setting
        PlayerPrefs.SetInt("TextSpeed", (int)textSpeedSlider.value);
        ApplySettingsToDialogueManager();
    }

    // Apply settings to the DialogueManager
    private void ApplySettingsToDialogueManager()
    {
        DialogueManager.Instance.SetLettersPerSecond(PlayerPrefs.GetInt("TextSpeed", 40));
    }
}
