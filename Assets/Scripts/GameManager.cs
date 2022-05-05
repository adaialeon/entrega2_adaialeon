using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private sfxManager sfxManager;

    private bgmManager bgmManager;

    private int coins;

    public Text coinsText;

    private int goombasNumber;

    public Text goombasText;

    public bool shootPowerUp = false;

    public float shootDuration = 5;

    public float shootTimer = 0;


    void Awake()

    {
        sfxManager = GameObject.Find("sfxManager").GetComponent<sfxManager>();
        bgmManager = GameObject.Find("bgmManager").GetComponent<bgmManager>();
    }

    void Update()
    {
        if(shootPowerUp == true)
        {
            if(shootTimer <= shootDuration)
            {
                shootTimer += Time.deltaTime;
            }
            else
            {
                shootPowerUp = false;
                shootTimer = 0f;
            }
        }
    }

    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
        Invoke("LoadMainMenu", 3);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void DeathGoomba(GameObject goomba)
    {

        //Funcion matar Goombas
        Animator goombaAnimator;

        //variable para el script del goomba
        Enemy goombaScript;

        //variable para el collider 
        BoxCollider2D goombaCollider;

        //Asignamos la variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("Enemydeath", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        // llamamos la funcion de sonido muerte gomba
        sfxManager.GoombaSound();

        //contar goombas
        goombasNumber++;

       /* goombasText.text = "Goombas: " + goombasNumber;*/

    }

    /*public void Catchcoin()
    {
        sfxManager.CoinSound();

        //contar monedas
        coins++;

        coinsText.text = "Coins: " + coins;
    }*/

    public void CatchFlag(GameObject Bandera)
    {
        BoxCollider2D BanderaCollider;
        //valor asignado
        BanderaCollider = Bandera.GetComponent<BoxCollider2D>();
        sfxManager.BanderaSound();
        SceneManager.LoadScene("FINAL");
    }

    public void BanderaVictoria (GameObject bandera)
    {
        BoxCollider2D banderaCollider;

        banderaCollider = bandera.GetComponent<BoxCollider2D>();

        sfxManager.CogerBandera();
    }


}