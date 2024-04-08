using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the loading of position data from a text file.
/// </summary>
public class LoadSystem : MonoBehaviour
{
    // File path where the position tracker file is located
    private string filePath = "./";

    // Name of the position tracker file
    private string posFileName = "posTracker.txt";

    /// <summary>
    /// Initiates the loading process.
    /// </summary>
    public void Load()
    {
        LoadPosition();
    }

    /// <summary>
    /// Loads position data from the position tracker file.
    /// </summary>
    private void LoadPosition()
    {
        // Check if the position tracker file exists
        if (!File.Exists(Path.Combine(filePath, posFileName)))
        {
            Debug.Log("Position Tracker File Not Found. Loading new game.");
            SceneManager.LoadSceneAsync(1);
            return;
        }

        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the scene has loaded completely
        asyncLoad.completed += (_) =>
        {
            // Find the player GameObject by tag
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // Check if player object is found
            if (playerObject != null)
            {
                Transform player = playerObject.transform;

                // Read position data from the file
                using (StreamReader inputFile = new StreamReader(Path.Combine(filePath, posFileName), true))
                {
                    string line = inputFile.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Convert string to Vector2 and assign it to the player's position
                        player.position = StringToVector2(line);
                    }
                }
            }
            else
            {
                Debug.Log("Player GameObject not found in scene!");
            }
        };
    }

    /// <summary>
    /// Converts a string representation of a vector to a Vector2 object.
    /// </summary>
    /// <param name="line">The string containing vector data.</param>
    /// <returns>A Vector2 object representing the parsed vector data.</returns>
    private Vector2 StringToVector2(string line)
    {
        // Create a Vector2 object
        Vector2 vector2 = new Vector2();

        // Extract x coordinate from the string
        string x = line.Substring(1, line.IndexOf(",") - 1);

        // Extract y coordinate from the string
        string y = line.Substring(x.Length + 3, line.Substring(x.Length + 3).IndexOf(","));
        y = y.Trim(' ');
        y = y.Trim(',');

        // Parse extracted coordinates to float and assign them to the Vector2 object
        vector2.x = float.Parse(x);
        vector2.y = float.Parse(y);

        // Return the Vector2 object
        return vector2;
    }
}
