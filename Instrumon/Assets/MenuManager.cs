using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject pauseMenu;

    void Update()
    {
        // Reverse the active state every time escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check whether it's active or inactive 
            bool isActive = pauseMenu.activeSelf;

            pauseMenu.SetActive(!isActive);
        }
    }
}