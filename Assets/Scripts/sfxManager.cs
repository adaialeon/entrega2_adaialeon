      using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
   
    // Clip de audio para muerte mario
    public AudioClip deathSFX;

    //Clip de audio muerte goomba
    public AudioClip goombaSFX;
   
    // Variable del audio source
    private AudioSource _audioSoucer;

    public AudioClip coinSFX;

    public AudioClip banderaSFX;

    
    void Awake()
    {
        _audioSoucer = GetComponent<AudioSource>();

    }
  
    public void DeathSound()
    {
        _audioSoucer.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
        _audioSoucer.PlayOneShot(goombaSFX);
    }

    public void CoinSound()
    {
        _audioSoucer.PlayOneShot(coinSFX);
    }

    public void BanderaSound()
    {
        _audioSoucer.PlayOneShot(banderaSFX);
    }

    public void CogerBandera()
    {
        _audioSoucer.PlayOneShot(banderaSFX);
    }


}