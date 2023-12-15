using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour // Add to game object and it follows the assigned waypoints
{
    [SerializeField] GameObject[] waypoints; // Creates a UI in the unity editor to insert and waypoints
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f; // Creates UI to adjust speed of the object

    void Update() // Checks every frame
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f) // When the object arrives at waypoint (very closely) then proceed to next if statement
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // Proceed to next waypoint
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime); // Keeps speed constant at different frame rates
    }
}
