using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SaveTest
{
    [UnityTest]
    public IEnumerator SaveTestEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        SceneManager.LoadScene("WorldLayer-Brass");
        yield return null;

        var playerObject = GameObject.Find("Player");
        var teleobject = GameObject.Find("TeleportBrassDestOut");
        Assert.IsNotNull(playerObject);
        yield return new WaitForSeconds(1f);
        var player = playerObject.GetComponent<PlayerController>();

        player.setistesting(true);

        player.testinput(1, 0);
        yield return new WaitForSeconds(1f);

        //move Up with input
        player.testinput(0f,1f);
        yield return new WaitForSeconds(1f);

        //move Left with input
        player.testinput(-1f, 0f);
        yield return new WaitForSeconds(1f);

        Vector3 savedPosition = playerObject.transform.position;

        //Simulating the player defeating the first musician
        ProgressFlags.UpdateFlag(2);

        Assert.AreEqual(ProgressFlags.GetFlag(), 2);
        var pauseObject = GameObject.Find("PauseMenuCanvas");
        var pausePanel = pauseObject.GetComponentInChildren<Transform>().Find("Pause Menu Panel");
        var saveSystem = pausePanel.GetComponent<SaveSystemMk2>();

        //Saving the game at position with current progress
        saveSystem.Save();

        //Reloading scene so that it becomes default
        SceneManager.LoadScene("WorldLayer-Brass");
        yield return null;

        //Ensuring the progress flag is in the default/starting state
        Assert.AreEqual(ProgressFlags.GetFlag(), 1);

        saveSystem.Load();
        Assert.AreEqual(savedPosition, playerObject.transform.position);


        player.setistesting(false);
    }
}
