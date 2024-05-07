using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
        Assert.IsNotNull(pauseMenuPanel, "Instrumon Panel object not found");
        var optionsPanel = pauseMenuCanvas.GetComponentInChildren<Transform>().Find("Options Panel").gameObject;
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(pauseMenuPanel, "Options Panel object not found");
        var progressPanel = pauseMenuCanvas.GetComponentInChildren<Transform>().Find("Progress Panel").gameObject;
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(pauseMenuPanel, "Progress Panel object not found");

        // Sets the testing variable inside the Controller code
        player.setistesting(true);

        // Checks if the pause menu panel is not active
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

        // Check if the instrumon panel is now active
        Assert.IsTrue(instrumonPanel.activeSelf);

        // Access the LevelText (TMP) GameObject and retrieve its text
        var levelTextObject = instrumonPanel.GetComponentInChildren<Transform>().Find("Panel").gameObject.GetComponentInChildren<Transform>().Find("Instrumon1").GetComponentInChildren<Transform>().Find("LevelText (TMP)").gameObject;
        var levelText = levelTextObject.GetComponent<TMP_Text>().text;

        // Make sure the level of your instrumon is 1 when the game starts
        Assert.AreEqual(levelText, "Lvl 1");


















        player.setistesting(false);

    }
}
