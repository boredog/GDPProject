using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : MonoBehaviour
{
    //Email pop-up
    public GameObject email;
    public string btn;
    public AudioSource song;
    public AudioSource main;
    public AudioSource popUp;
    public void PopEmail()
    {
        email.gameObject.SetActive(true);
        btn = this.name;
        main.Stop();
        song.Play();
        popUp.Play();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public string Btn
    {
        get { return btn; }
    }
}
