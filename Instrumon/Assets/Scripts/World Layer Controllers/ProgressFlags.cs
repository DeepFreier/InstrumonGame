using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressFlags : MonoBehaviour
{
    public static int Flag = 1;

    public static int returnFlag()
    {
        return Flag;
    }

    public static void UpdateFlag(int newflag)
    {
        ProgressFlags.Flag = newflag;
    }
    public static int GetFlag()
    {
        return ProgressFlags.Flag;
    }
}
