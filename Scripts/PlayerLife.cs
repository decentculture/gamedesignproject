using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour // Script for killing player
{
    bool dead = false; // bool for false to true for later script

    [SerializeField] AudioSource deathSound; // Adds the UI in editor needed to put in sound when player dies

    private void Update() // Checks every frame
    {
        if (transform.position.y < -3f && !dead) // If player falls below this y axis position then DIE!
        {
            Die(); // Die.  (the script is down there)
        }
    }



    private void OnCollisionEnter(Collision collision) // Script for killing player when hitting the enemy or very dangerous objects but mostly enemies
    {
        if (collision.gameObject.CompareTag("Enemy Body")) // If the player hits something with the tag "Enemy Body" then the player dies
        {
            GetComponent<MeshRenderer>().enabled = false; // turns player invisible by switching meshrenderer from on to off
            GetComponent<Rigidbody>().isKinematic = true; // stops player from having physics
            GetComponent<MyPlayerMovement>().enabled = false; // stops the actual player from moving the player character :)
            Die(); // ok die.
        }
;
    }

    void Die() // Script for what happens next when player die
    {
        Invoke(nameof(ReloadLevel), 1.3f); // Reloads the level after a delay of 1.3 seconds
        dead = true; // true. player is dead. That's for the bool from earlier at the top.
        deathSound.Play(); // plays DEH.mp3 from Roblox. The death dying sound.
    }

    void ReloadLevel() // Script for reloading the level the player is currently on. The ACTIVE scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
