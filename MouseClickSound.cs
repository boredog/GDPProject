using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSound : MonoBehaviour
{
    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;
    public AudioSource m4;
    int click;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            click = Random.Range(1, 4);
            if(click is 1)
            {
                m1.Play();
            }
            if (click is 2)
            {
                m2.Play();
            }
            if (click is 3)
            {
                m3.Play();
            }
            if (click is 4)
            {
                m4.Play();
            }
        
    }
    }
    }
