using UnityEngine;
using System.IO;

/// <summary>
/// Manages the saving of player position data to a text file.
/// </summary>
public class SaveSystem : MonoBehaviour
{
    // File path where the position tracker file is located
    private string filePath = "./";

    // Name of the position tracker file
    private string posFileName = "posTracker.txt";

    /// <summary>
    /// Saves the current player position to a text file.
    /// </summary>
    public void Save()
    {
        SavePosition();
    }

    /// <summary>
    /// Saves the current player position to a text file.
    /// </summary>
    private void SavePosition()
    {
        // Find the player GameObject by tag and get its transform component
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // Log the file path where the position data will be saved
        Debug.Log("Saved Position to: " + filePath + posFileName);

        // Delete the existing position tracker file (if any)
        File.Delete(Path.Combine(filePath, posFileName));

        // Write the player's position to the position tracker file
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, posFileName), true))
        {
            // Write the player's position as a line in the text file
            outputFile.WriteLine(player.position);
        }
    }
}
