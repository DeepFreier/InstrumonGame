using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using System.Linq;

public class SaveSystemMk2 : MonoBehaviour
{
    public static SaveSystemMk2 ins;




    private void Awake()
    {

        ins = this;

    }




    //Creates a public instance of the Savedatabase
    public SaveDatabase SD;



    public void Save()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Transform playerpos = Player.transform;
        List<Instrumon> PlayerMon = Player.GetComponent<PlayerController>().playerparty;
        List<int> health = new List<int>();
        foreach (var instrumon in PlayerMon)
        {
            int currhealth = instrumon.Base.CurrentHP;
            health.Add(currhealth);
        }
        SD.MonHealth = health;
        SD.Flag = ProgressFlags.GetFlag();
        SD.PlayerPosx = playerpos.position.x;
        SD.PlayerPosy = playerpos.position.y;
        //Opens a new XML File and saves to it, or overwrites a file with the same name
        XmlSerializer serializer = new(typeof(SaveDatabase));
        FileStream stream = new(Application.dataPath + "/SaveFile/SaveData.xml", FileMode.Create);
        serializer.Serialize(stream, SD);
        stream.Close();
    }

    public void Load()
    {
        if (File.Exists(Path.Combine(Application.dataPath + "/SaveFile/SaveData.xml")))
        {
            Vector2 PlayerPosn;
            XmlSerializer serializer = new(typeof(SaveDatabase));
            FileStream stream = new(Application.dataPath + "/SaveFile/SaveData.xml", FileMode.Open);
            SaveDatabase OSD = serializer.Deserialize(stream) as SaveDatabase;
            PlayerPosn.x = OSD.PlayerPosx;
            PlayerPosn.y = OSD.PlayerPosy;
            int Flag = OSD.Flag;
            List<int> health = OSD.MonHealth;
            Debug.Log("Player X:" + PlayerPosn.x);
            Debug.Log("Player Y:" + PlayerPosn.y);
            Debug.Log("Flag:" + Flag);
            Debug.Log("Loading File");
            LoadPosition(PlayerPosn, Flag, health);
            stream.Close();
        }
        else
        {
            Debug.Log("Position Tracker File Not Found. Loading new game.");
            SceneManager.LoadSceneAsync(1);
            Debug.Log("Progress Flag:" + ProgressFlags.Flag);
        }

    }
    // Delete the save file
    public void DeleteSaveFile()
    {
        string filePath = Application.dataPath + "/SaveFile/SaveData.xml";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.Log("Save file does not exist.");
        }
    }

    //Loads Player Position
    private void LoadPosition(Vector2 PlayerPos, int ProFlag, List<int> PlayerMonHealth)
    {
        // Check if the position tracker file exists
        if (!File.Exists(Path.Combine(Application.dataPath + "/SaveFile/SaveData.xml")))
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
            List<Instrumon> playermon = playerObject.GetComponent<PlayerController>().playerparty;

            // Check if player object is found
            if (playerObject != null)
            {
                Debug.Log("Loading Transform");
                Transform player = playerObject.transform;
                player.position = PlayerPos;
                for (int i = 0; i < 4; i++)
                {
                    playermon[i].Base.CurrentHP = PlayerMonHealth[i];
                }
                ProgressFlags.UpdateFlag(ProFlag);
                int CurrFlag = ProgressFlags.GetFlag();
                Debug.Log(CurrFlag);
            }
            else
            {
                Debug.Log("Player GameObject not found in scene!");
            }
        };

    }
}


/*[System.Serializable] 
public class PosEntry
{
  public Transform Player = GameObject.FindGameObjectWithTag("Player").transform;
}*/

/*[System.Serializable]
public class FlagEntry
{

    public int Flag = GameController.currentFlag;
    
}*/

[Serializable]
public class SaveDatabase
{
    public float PlayerPosx = 0;
    public float PlayerPosy = 0;
    public int Flag = 1;
    public List<int> MonHealth = new List<int>();
}





