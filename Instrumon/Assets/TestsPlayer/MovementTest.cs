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
        //Grabs the Player object and it's controller
        var playerObject = GameObject.Find("Player");
        var teleobject = GameObject.Find("TeleportBrassDestOut");
        Assert.IsNotNull(playerObject);
        yield return new WaitForSeconds(1f);
        var player = playerObject.GetComponent<PlayerController>();

        //Sets the testing variable inside the Controller code
        player.setistesting(true);
        
        //Checks if the player can move Right with input
        Vector3 playeroldpos = playerObject.transform.position;
        player.testinput(1, 0);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        //Checks if the player can move Up with input
        playeroldpos = playerObject.transform.position;
        player.testinput(0f,1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        //Checks if the player can move Left with input
        playeroldpos = playerObject.transform.position;
        player.testinput(-1f, 0f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        //Checks if the player can move Down with input
        playeroldpos = playerObject.transform.position;
        player.testinput(0f, -1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        //Checks if the diagonal system is working
        playeroldpos = playerObject.transform.position;
        player.testinput(1f, 1f);
        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(playeroldpos, playerObject.transform.position);

        //Stops player movement and checks that the player is in fact not moving
        //All of these satisfy the movement portion of the Player Movement User Story
        playeroldpos = playerObject.transform.position;
        player.testinput(0f, 0f);
        yield return new WaitForSeconds(1f);

        Assert.AreEqual(playeroldpos, playerObject.transform.position);

        //Checks if collisions are working by running player into wall
        //This satisfies the solid objects stopping player portion of the Player Movement User Story
        playeroldpos = playerObject.transform.position;
        player.testinput(1f, 0f);
        yield return new WaitForSeconds(1f);

        Assert.AreEqual(playeroldpos, playerObject.transform.position);

        //Stops player movement and teleports player to in front of club
        player.testinput(0f, 0f);
        player.transform.position = teleobject.transform.position;
        yield return new WaitForSeconds(1f);

        //Sends player through club door and checks if they teleported.
        //This satisfies the transition portion of the Player Movement User Story
        player.testinput(0f, 1f);
        yield return new WaitForSeconds(1f);
        Assert.IsTrue(player.transform.position.x > 60);



        player.setistesting(false);
        
    }
}
