using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustFinish : MonoBehaviour // Script for finish line of levels or scenes
{
    private void OnTriggerEnter(Collider other) // When player collides with this then run script (OnTrigger so player can phase through instead of hitting its head on it)
    {
        if (other.gameObject.name == "player") // checks for the actual player object by specifying it with the name over here
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next scene using scene manager, next scene in the order of whats in the build settings
        }
    }
}
