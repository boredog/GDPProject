using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailIcon : MonoBehaviour
{
    public GameObject email;
    public Gameplay gameScript;


    private void Start()
    {

    }
    public void ButtonFunction()
    {
        gameScript.BringUpEmail();
    }
}
