using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ProgressTextUpdater : MonoBehaviour
{
    public TMP_Text progressText;

    private void Update()
    {
        UpdateProgressText();
    }

    public void UpdateProgressText()
    {
        if (ProgressFlags.GetFlag() == 1)
        {
            progressText.text = $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the first musician somewhere near the seadocks.";
        }
        else if (ProgressFlags.GetFlag() == 2)
        {
            progressText.text = $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musician. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"You should find the Musician Frank next, he's somewhere up north.\"";
        }
        else if (ProgressFlags.GetFlag() == 3)
        {
            progressText.text = $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"You should find Karl next. He's in the park in the west side of town.\"";
        }
        else if (ProgressFlags.GetFlag() == 4)
        {
            progressText.text = $"The player has defeated {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Find the next musician somewhere in the world. Words echo in your mind:\n\n\"Go ahead and find Joseph near the northern tunnel.\"";
        }
        else if (ProgressFlags.GetFlag() == 5)
        {
            progressText.text = $"The player has defeated all {(ProgressFlags.GetFlag() - 1).ToString()} musicians. Congratulations! You have beat the game!";
        }
    }
}
