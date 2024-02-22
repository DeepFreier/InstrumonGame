using UnityEngine;
using System.IO;

public class LoadSystem : MonoBehaviour
{
    private string filePath = "./";
    private string posFileName = "posTracker.txt";

    public void Load()
    {
        LoadPosition();
    }

    private void LoadPosition()
    {
        if (!File.Exists(Path.Combine(filePath, posFileName)))
        {
            Debug.Log("Position Tracker File Not Found!");
            return;
        }

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        using (StreamReader inputFile = new StreamReader(Path.Combine(filePath, posFileName), true))
        {
            string line = inputFile.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                player.position = StringToVector2(line);
                line = inputFile.ReadLine();
            }
        }
    }

    private Vector2 StringToVector2(string line)
    {
        Vector2 vector2 = new Vector2();
        string x = line.Substring(1, line.IndexOf(",") - 1); //avoid beginning paren and dont include comma
        string y = line.Substring(x.Length + 3, line.Substring(x.Length + 3).IndexOf(","));
        y = y.Trim(' ');
        y = y.Trim(',');
        vector2.x = float.Parse(x);
        vector2.y = float.Parse(y);
        return vector2;
    }
}
