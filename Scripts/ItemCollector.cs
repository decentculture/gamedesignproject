using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour // Script for collecting the coins (this is put on the player)
{
    int coins = 0; // it is a counter for how many coins the player got and is used for the gameplay UI

    [SerializeField] Text coinsText; // Creates UI in editor to put the coins in
    [SerializeField] AudioSource collectionSound; // Creates UI to put the satisfying sound in

    private void OnTriggerEnter(Collider other) // Checks for collision
    {
        if (other.gameObject.CompareTag("Coin")) // if the player collides with the coin then (run script) bling bling money money dolla dolla bills yo
        {
            Destroy(other.gameObject); // Removes the object from the scene
            coins++; // add counter to coins
            coinsText.text = "Coins: " + coins; // now show me the money (on the gameplay UI)
            collectionSound.Play(); // play that KACHING sound lets goooooo
        }
    }
}
