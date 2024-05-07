using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class PauseMenuTest
{
    [UnityTest]
    public IEnumerator PauseMenuTestWithEnumeratorPasses()
    {
        // Check for Player Object
        SceneManager.LoadScene("WorldLayer-Brass");
        yield return null;

        // Grabs the Player object and its controller the pause menu canvas
        var playerObject = GameObject.Find("Player");
        Assert.IsNotNull(playerObject);
        yield return new WaitForSeconds(1f);
        var player = playerObject.GetComponent<PlayerController>();

        // Grabs the pause menu canvas and all the panels
        GameObject pauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
        yield return new WaitForSeconds(1f);
        Assert.IsNotNull(pauseMenuCanvas, "PauseMenuCanvas object not found");
        var pauseMenuPanel = pauseMenuCanvas.GetComponentInChildren<Transform>().Find("Pause Menu Panel").gameObject;
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(pauseMenuPanel, "Pause Menu Panel object not found");
        var instrumonPanel = pauseMenuCanvas.GetComponentInChildren<Transform>().Find("Instrumon Panel").gameObject;
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(instrumonPanel, "Instrumon Panel object not found");
        var progressPanel = pauseMenuCanvas.GetComponentInChildren<Transform>().Find("Progress Panel").gameObject;
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(progressPanel, "Progress Panel object not found");
        
        // Sets the testing variable inside the Controller code
        player.setistesting(true);

        // Checks if the pause menu panel is not active on startup
        yield return new WaitForSeconds(1f);
        Assert.IsFalse(pauseMenuPanel.activeSelf);

        // Simulate pressing the escape key by toggling pause menu
        pauseMenuPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Check if the pause menu panel is now active
        Assert.IsTrue(pauseMenuPanel.activeSelf);

        // Toggle the instrumon panel
        instrumonPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Access the LevelText (TMP) GameObject and retrieve its text
        var levelTextObject = instrumonPanel.GetComponentInChildren<Transform>().Find("Panel").gameObject.GetComponentInChildren<Transform>().Find("Instrumon1").GetComponentInChildren<Transform>().Find("LevelText (TMP)").gameObject;
        var levelText = levelTextObject.GetComponent<TMP_Text>().text;

        // Make sure the level of your instrumon is 1 when the game starts
        Assert.AreEqual(levelText, "Lvl 1");

        // Close the instrumon panel
        instrumonPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Toggle the progress panel
        progressPanel.SetActive(true);

        // Access the Progress Text (TMP) GameObject and retrieve its text
        var progressPanelObject = progressPanel.GetComponentInChildren<Transform>().Find("Panel").gameObject;
        var progressTextObject = progressPanelObject.GetComponentInChildren<Transform>().Find("Text (TMP)").gameObject;
        var progressText = progressTextObject.GetComponent<TMP_Text>().text;

        // Update the progress text and level text with a script
        var updater = progressPanelObject.GetComponentInChildren<ProgressTextUpdater>();
        var levelUpdater = instrumonPanel.GetComponent<ButtonUpdater>();
        updater.UpdateProgressText();
        levelUpdater.UpdateInstrumonNames();
        progressText = progressTextObject.GetComponent<TMP_Text>().text;

        // Make sure the progress text says what it is supposed to say
        Assert.AreEqual(progressText, $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the first musician somewhere near the seadocks.");

        // Close the progress panel
        progressPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Update the progress flag to simulate the player beating the first musician and update the progress text and level text
        ProgressFlags.UpdateFlag(2);
        updater.UpdateProgressText();
        levelUpdater.UpdateInstrumonNames();
        progressText = progressTextObject.GetComponent<TMP_Text>().text;
        levelText = levelTextObject.GetComponent<TMP_Text>().text;

        // Toggle the instrumon panel
        instrumonPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Make sure the level of your instrumon is lvl 2
        Assert.AreEqual(levelText, "Lvl 2");

        // Close the instrumon panel
        instrumonPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Toggle the progress panel
        progressPanel.SetActive(true);

        // Make sure the progress text says what it is supposed to say
        Assert.AreEqual(progressText, $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musician. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"You should find the Musician Frank next, he's somewhere up north.\"");

        // Close the progress panel
        progressPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Update the progress flag to simulate the player beating the second musician and update the progress text and level text
        ProgressFlags.UpdateFlag(3);
        updater.UpdateProgressText();
        levelUpdater.UpdateInstrumonNames();
        progressText = progressTextObject.GetComponent<TMP_Text>().text;
        levelText = levelTextObject.GetComponent<TMP_Text>().text;

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        // Toggle the instrumon panel
        instrumonPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Make sure the level of your instrumon is lvl 3
        Assert.AreEqual(levelText, "Lvl 3");

        // Close the instrumon panel
        instrumonPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Toggle the progress panel
        progressPanel.SetActive(true);

        // Make sure the progress text says what it is supposed to say
        Assert.AreEqual(progressText, $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"You should find Karl next. He's in the park in the west side of town.\"");

        // Close the progress panel
        progressPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Update the progress flag to simulate the player beating the third musician and update the progress text and level text
        ProgressFlags.UpdateFlag(4);
        updater.UpdateProgressText();
        levelUpdater.UpdateInstrumonNames();
        progressText = progressTextObject.GetComponent<TMP_Text>().text;
        levelText = levelTextObject.GetComponent<TMP_Text>().text;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // Toggle the instrumon panel
        instrumonPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Make sure the level of your instrumon is lvl 4
        Assert.AreEqual(levelText, "Lvl 4");

        // Close the instrumon panel
        instrumonPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Toggle the progress panel
        progressPanel.SetActive(true);

        // Make sure the progress text says what it is supposed to say
        Assert.AreEqual(progressText, $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"Go ahead and find Joseph near the northern tunnel.\"");

        // Close the progress panel
        progressPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Update the progress flag to simulate the player beating the fourth musician and update the progress text and level text
        ProgressFlags.UpdateFlag(5);
        updater.UpdateProgressText();
        levelUpdater.UpdateInstrumonNames();
        progressText = progressTextObject.GetComponent<TMP_Text>().text;
        levelText = levelTextObject.GetComponent<TMP_Text>().text;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Toggle the instrumon panel
        instrumonPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Make sure the level of your instrumon is lvl 5
        Assert.AreEqual(levelText, "Lvl 5");

        // Close the instrumon panel
        instrumonPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        // Toggle the progress panel
        progressPanel.SetActive(true);

        // Make sure the progress text says what it is supposed to say
        Assert.AreEqual(progressText, $"The player has defeated all {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Congratulations! You have beat the game!");

        // Close the progress panel
        progressPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        player.setistesting(false);
    }
}
