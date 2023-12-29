using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWaypoint = 0;

    public float speed = 0.3f;
    
    void FixedUpdate()
    {
        float distanceToWaypoint = Vector2.Distance((Vector2)this.transform.position, (Vector2)waypoints[currentWaypoint].position);

        if (distanceToWaypoint < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                Vector2 newDirection = waypoints[currentWaypoint].position - this.transform.position;
                GetComponent<Animator>().SetFloat("DirX", newDirection.x);
                GetComponent<Animator>().SetFloat("DirY", newDirection.y);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Pacman")
        {
            Destroy(otherCollider.gameObject);
        }
    }
}
