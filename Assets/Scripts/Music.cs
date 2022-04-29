using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    
     
     public AudioSource _AudioSource;

    public AudioClip _AudioClip1;
    public Text playingMusic;
    public AudioClip _AudioClip2;
    public AudioClip _AudioClip3;
    public AudioClip _AudioClip4;
    public AudioClip _AudioClip5;

    

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {



            _AudioSource.clip = _AudioClip1;

            _AudioSource.Play();
            playingMusic.text = "Now Playing = Hang'em All";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _AudioSource.clip = _AudioClip2;

            _AudioSource.Play();
            playingMusic.text = "Now Playing = Labyrinth";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _AudioSource.clip = _AudioClip3;

            _AudioSource.Play();
            playingMusic.text = "Now Playing = Spotlight";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _AudioSource.clip = _AudioClip4;

            _AudioSource.Play();
            playingMusic.text = "Now Playing = D.A.N.C.E";

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _AudioSource.clip = _AudioClip5;

            _AudioSource.Play();
            playingMusic.text = "Now Playing = Kill V. Maim";

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playingMusic.text = "";
            _AudioSource.Stop();


        }




    }

    }

