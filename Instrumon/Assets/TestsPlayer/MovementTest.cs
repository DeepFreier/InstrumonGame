using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MovementTest
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MovementTestWithEnumeratorPasses()
    {


        //Check for Player Object
        SceneManager.LoadScene("WorldLayer-Brass");
        yield return null;
        
        var playerObject = GameObject.Find("Player");
        Assert.IsNotNull(playerObject);
        yield return new WaitForSeconds(1f);
        var player = playerObject.GetComponent<PlayerController>();

        player.setistesting(true);
        
        Vector3 playeroldpos = playerObject.transform.position;
        player.testinput(1, 0);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        playeroldpos = playerObject.transform.position;
        player.testinput(0f,1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        playeroldpos = playerObject.transform.position;
        player.testinput(-1f, 0f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        playeroldpos = playerObject.transform.position;
        player.testinput(0f, -1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        playeroldpos = playerObject.transform.position;
        player.testinput(1f, 1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        playeroldpos = playerObject.transform.position;
        player.testinput(0f, 0f);
        yield return new WaitForSeconds(1f);

        Assert.AreEqual(playeroldpos, playerObject.transform.position);

        player.testinput(0f, 0f);
        player.setistesting(false);
        
    }
}
