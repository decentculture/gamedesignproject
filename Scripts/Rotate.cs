using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedX; // all of these serialized float speed
    [SerializeField] float speedY; // just means a UI was created in editor to change these values on the spot
    [SerializeField] float speedZ; // for the X Y and Z axis of course
    void Update() // Update every frame
    {
        transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime); // The rotation degree and keeps rotation speed constant
    }
}
