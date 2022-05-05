using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable para controlar la velocidad del goomba
    public float speed = 4.5f;

    // variable para saber en que direccion se mueve en el eje X
    private int directionX = 1; 

    // variable para almacenar el rigidbody del enemigo
    private Rigidbody2D rigidBody; 

    //variable para saber si el goomba esta muerto
    public bool isAlive = true;

    private GameManager gameManager;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if(isAlive)
        {
            //anade velocidad en el eje X
            rigidBody.velocity = new Vector2(- directionX * speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "pared")
        {
            // si detecta colision con un objeto con tag "pared"
            Debug.Log("me he chocado");

            // si nos movemos a la derecha cambiara la direccion de movimiento a la izquierda (carlos es gay)
            if(directionX == 1)
            {
                directionX = -1;
            }
            else
            {
                directionX = 1;
            }
        }

        // si choca el mario lo destruye 
        else if (hit.gameObject.tag == "MuereAtenea")
        {
            Destroy(hit.gameObject); 
            gameManager.DeathMario();
        }
    }
}
