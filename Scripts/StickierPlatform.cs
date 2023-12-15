using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickierPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) // Script for collision with floor and player
    {
        if (collision.gameObject.name == "player") // Checks if it IS collided with "player"
        {
            collision.gameObject.transform.SetParent(transform); // Sets "player" as child of the floor or game object so that when the parent floor moves the player moves along with it and doesn't slide off
        }
    }

    private void OnCollisionExit(Collision collision) // Script for after the collision with floor and player
    {
        if (collision.gameObject.name == "player") // same thing, checks if it IS collided with "player"
        {
            collision.gameObject.transform.SetParent(null); // Takes off the player as child of the object
        }
    }
}
