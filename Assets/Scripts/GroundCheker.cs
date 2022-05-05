using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheker : MonoBehaviour

{
    public Player _player; 


    void Awake()
    {
        _player = GameObject.Find("atenea").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _player._animator.SetBool("Jumping", false);
    }


    void OnTriggerStay2D(Collider2D col)
    {
        _player.isGorounded = true;
        
    }

    void OnTriggerExit2D(Collider2D col)

    {
        _player.isGorounded = false;
    }

}