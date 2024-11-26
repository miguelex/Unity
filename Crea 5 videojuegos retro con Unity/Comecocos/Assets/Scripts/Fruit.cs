using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Pacman")
        {
            UIManager.sharedInstance.ScorePoint(500);
            GameManager.sharedInstance.MakeInvicibleFor(15.0f);
            Destroy(this.gameObject);
        }
    }
}
