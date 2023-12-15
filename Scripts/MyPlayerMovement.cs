using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour // Movement script and more actually
{
    Rigidbody zeri;
    [SerializeField] float movementSpeed = 6f; // Creates a UI to easily change movement speed, the default is 6 for whatever unit that is
    [SerializeField] float jumpForce = 6f; // and jump force, aka height

    [SerializeField] Transform groundCheck; // Creates UI
    [SerializeField] LayerMask ground; // Creates UI

    [SerializeField] AudioSource jumpSound; // Creates UI
    [SerializeField] AudioSource enemydieSound; // Creates UI

    // Start is called before the first frame update
    void Start()
    {
        zeri = GetComponent<Rigidbody>(); // makes the word 'zeri' mean GetComponent<Rigidbody>(); ... just makes the script cleaner by shortening some stuff
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // uses the unity input manager that's built in
        float veritcalInput = Input.GetAxis("Vertical"); // to use the keys associated with those for horizontal and vertical movement

        zeri.velocity = new Vector3(horizontalInput * movementSpeed, zeri.velocity.y, veritcalInput * movementSpeed); // When WASD is pressed, move in that direction with the float values assigned

        if (Input.GetButtonDown("Jump") && IsGrounded()) // When spacebar is pressed AND player is on the ground then it is ok to jump
        {
            Jump(); // JUMP! the script is at the bottom, this calls for that script
        }
       
    }

    void Jump() // JUMP! No seriously, jump!
    {
        zeri.velocity = new Vector3(zeri.velocity.x, jumpForce, zeri.velocity.z); // zeri is the word used to replace that long word earlier, those vectors are for the direction of jumping
        jumpSound.Play(); // plays the assigned jumping sound, very fun
    }

    private void OnCollisionEnter(Collision collision) // Script for Mario-ing the enemies
    {
        if (collision.gameObject.CompareTag("Enemy Head")) // The enemies have two hitboxes, body and head, this one is for head and checks if player collides with head
        {
            enemydieSound.Play(); // WHAT IS THAT MELODY? The enemies dying! HAHAHAHA
            Destroy(collision.transform.parent.gameObject, .25f); // Destroys the enemy's body and leaves no remains but after .25 seconds lol (the head is a child of the enemy object in the heirachy)
            Jump(); // Mario! Jump again because it is so joyous to kill enemies. Automatically jumps.
        }
    }
    
    bool IsGrounded() // The true or false code for being grounded to the ground
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground); // Grouned? Yes? ok. Grounded? No? why not?! (It is used to prevent infinite jumping for the jump script)
    }
}
