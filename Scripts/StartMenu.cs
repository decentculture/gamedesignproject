using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame() // Script for Start Menu button for starting the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Uses scenemanager to load next scene
    }
}
