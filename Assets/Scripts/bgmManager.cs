using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager : MonoBehaviour
{
    
    private AudioSource _audioSoucer;

    void Awake()
    {
        //Asignamos la variable
        _audioSoucer = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Reproducimos la musica
        _audioSoucer.Play();
    }

    public void StopBGM()
    {
        _audioSoucer.Stop();
    }
}
