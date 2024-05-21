using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.4f;

    Vector2 destination = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        destination = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.sharedInstance.gameStarted && !GameManager.sharedInstance.gamePaused)
        {
            GetComponent<AudioSource>().volume = 0.5f;
            
            // Calculamos el nuevo punto donde hay que ir en base a la variable destino
            Vector2 newPos = Vector2.MoveTowards(this.transform.position, destination, speed*Time.deltaTime);
        
            //usamos  el rigidbody para transportar a Pacman a dicha posición
            GetComponent<Rigidbody2D>().MovePosition(newPos);

            float distanceToDestination = Vector2.Distance((Vector2)this.transform.position, destination);

            if (distanceToDestination < 2.0f)
            {
                if (Input.GetKey(KeyCode.UpArrow) && CanMoveTo(Vector2.up))
                {
                    destination = (Vector2)this.transform.position + Vector2.up;
                }
                if (Input.GetKey(KeyCode.DownArrow) && CanMoveTo(Vector2.down))
                {
                    destination = (Vector2)this.transform.position + Vector2.down;
                }
                if (Input.GetKey(KeyCode.LeftArrow) && CanMoveTo(Vector2.left))
                {
                    destination = (Vector2)this.transform.position + Vector2.left;
                }
                if (Input.GetKey(KeyCode.RightArrow) && CanMoveTo(Vector2.right))
                {
                    destination = (Vector2)this.transform.position + Vector2.right;
                }
            }

            Vector2 dir = destination - (Vector2)this.transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.0f;
        }

    }

    //Dada una posible direccio nde movimiento devuelve true si es posible moverse en esa direccion
    bool CanMoveTo(Vector2 dir)
    {
        Vector2 pacmanPos = this.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pacmanPos+ dir, pacmanPos);
        return hit.collider == GetComponent<Collider2D>();
    }
    
}
