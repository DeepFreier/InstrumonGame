using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{

    public static TeleporterManager Instance { get; private set; }

    //Sets the Instance var to whatever is invoking this class at that point
    private void Awake()
    {
        Instance = this;
    }
    public void Teleport(Transform thePlayer, Transform destination, GameObject thePlayerg)
    {
        thePlayerg.SetActive(false);
        thePlayer.position = destination.position;
        thePlayerg.SetActive(true);
    }

}
