using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Pacman")
        {
            UIManager.sharedInstance.ScorePoint(100);
            Destroy(this.gameObject);
        }
    }
}
