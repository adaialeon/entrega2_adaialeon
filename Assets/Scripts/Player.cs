using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player se mueva

public class Player : MonoBehaviour
{
    //variables para velocidad-fuerza de salto
    public float speed = 5f; 
    public float jumpForce = 10f;
    //variable para saber siestamos en el suelo
    public bool isGorounded;
    //variable para almacenar el movimiento
    float dirX; 

    //variables de componentes
    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _lorenabody; 

    public GameObject Proyectil;
    public Transform SpawnProyectil;

    void Awake()
    {

      //asignamos los componentes de las variables
      _animator = GetComponent<Animator>(); 
      _lorenabody = GetComponent<Rigidbody2D>();

    }

     void Update()
    {
      dirX = Input.GetAxisRaw("Horizontal");  

      Debug.Log(dirX);

      

       /*transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;*/

      if(dirX == -1)
      {
         //renderer.flipX = true; 
         _animator.SetBool("andar", true);
         transform.rotation = Quaternion.Euler(0,180,0);
      }
        else if(dirX == 1)
     {
        //renderer.flipX = false;
        _animator.SetBool("andar", true);
        transform.rotation = Quaternion.Euler(0,0,0);
    }
      else 
      {
        _animator.SetBool("andar", false);
      }

      if(Input.GetButtonDown("Jump") && isGorounded)
      {
        _lorenabody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        _animator.SetBool("saltar", true);
      }

      

      if (Input.GetButtonDown("Fire1"))
      {
        Instantiate(Proyectil, SpawnProyectil.position, SpawnProyectil.rotation);
      }
    }

     void FixedUpdate()
  {
  _lorenabody.velocity = new Vector2(dirX * speed, _lorenabody.velocity .y);

  }

}
