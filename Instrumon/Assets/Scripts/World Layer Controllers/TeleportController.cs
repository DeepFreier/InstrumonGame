using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour, Teleporter
{
    public Transform thePlayer, destination;
    public GameObject thePlayerg;


    public void Teleport()
    {
        //Debug.Log("You will start a battle!");
        TeleporterManager.Instance.Teleport(thePlayer, destination, thePlayerg);
    }

}
