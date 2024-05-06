using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BattleSwitchTest
{
    [UnityTest]
    public IEnumerator BattleSwitchTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("WorldLayer-Brass");
        yield return null;

        //Grabs the Player object and its controller
        var playerObject = GameObject.Find("Player");
        Assert.IsNotNull(playerObject, "Player object is null before teleportation");
        yield return new WaitForSeconds(1f);
        var player = playerObject.GetComponent<PlayerController>();

        //Sets the testing variable inside the Controller code
        player.setistesting(true);

        //Stops player movement and teleports player to first battle
        player.testinput(0f, 0f);
        player.transform.position = new Vector3(-0.5f, 1.89999962f, 0);
        player.testinput(0f, 1f);
        yield return new WaitForSeconds(1f);

        //Interacts with the first musician to start the first battle
        player.Interact();
        yield return new WaitForSeconds(3);

        ProgressFlags.updateOppParty();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BattleScene");
        yield return null;

        //Grabs the BattleController object
        var battleObject = GameObject.Find("BattleCanvas");
        Assert.IsNotNull(battleObject);
        yield return new WaitForSeconds(1f);
        var battle = battleObject.GetComponent<BattleController>();
        yield return new WaitForSeconds(1f);

        //tests switching by triggering the function that is called when the mon2 button is pressed
        battle.OnMon2();
        yield return new WaitForSeconds(2);
        //Asserts that the switch has actually occurred
        Assert.IsTrue(BattleController.playerCurrentMon == BattleController.playerParty[1], "Player current mon is not as expected after switching");
        yield return new WaitForSeconds(1f);
        //The visuals shown are irrelevant because if the object is correct, the visuals will reflect that

        // You can add similar tests for other scenarios...

        //battle.OnMon3();
        //yield return new WaitForSeconds(3);
        //Assert.IsTrue(BattleController.playerCurrentMon == BattleController.playerParty[1]);
    }
}