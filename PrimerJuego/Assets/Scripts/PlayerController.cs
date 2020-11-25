using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;
    
    public float jumpForce = 6.0f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runningSpeed = 1.0f;

    private Vector3 startPosition;
    private string highScoreKey = "highscore";
    void Awake()
    {
        sharedInstance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
        animator.SetBool("isAlive", true);
    }
    
    // Start is called before the first frame update
    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = startPosition;
        rigidBody.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
            animator.SetBool("isGrounded", IsOnTheFloor());
        }
        
    }

    private void FixedUpdate()
    {
        // Equiespacia los frames
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
                {
                    rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
                }
        }
        
        
    }

    void Jump()
    {
        if (IsOnTheFloor())
        {
            rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsOnTheFloor()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void KillPlayer()
    {
        GameManager.sharedInstance.GameOver();
        animator.SetBool("isAlive", false);

        if (PlayerPrefs.GetFloat(highScoreKey, 0) < this.GetDistance())
        {
            PlayerPrefs.SetFloat(highScoreKey, this.GetDistance());
        }
    }

    public float GetDistance()
    {
        float distanceTraveller =
            Vector2.Distance(new Vector2(startPosition.x, 0), new Vector2(this.transform.position.x, 0));

        return distanceTraveller;

    }
}
