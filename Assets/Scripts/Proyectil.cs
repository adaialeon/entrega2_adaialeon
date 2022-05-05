using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    //velocidad bala
    public float bulletSpeed;

    private Rigidbody2D carlosBody;

    private GameManager gameManager;

    void Awake()
    {
        carlosBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        carlosBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    //bala se destruye cuando choque contra algo
    void OnTriggerEnter2D(Collider2D collider)
    {
        //matamos goombas a balazos
        if(collider.gameObject.tag == "Enemy")
        {
            //destruye la bala
            Destroy(gameObject);
            //destruye el goomba
            gameManager.DeathGoomba(collider.gameObject);

        }
        
         if(collider.gameObject.tag == "Monedas")
         {

         }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
