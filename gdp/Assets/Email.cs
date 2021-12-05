using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Email : MonoBehaviour
{
    //Email pop-up
    public GameObject email;
    float time;
    public bool timerStart, called;
    public Text timeText;
    public GameObject playerHealth;
    public AudioSource song;
    public AudioSource main;
    public AudioSource popUp;
    public void PopEmail()
    {
        email.gameObject.SetActive(true);
        timerStart = true;
        main.Stop();
        song.PlayDelayed(1);
        popUp.Play();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        timerStart = false;
        called = false;
        email.SetActive(false);
    }

    public void Update()
    {
        Debug.Log(Input.mousePosition);
        if (email.gameObject.activeInHierarchy == true)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                Debug.Log("Time has run out!");
                time = 0;
                timerStart = false;
                email.SetActive(false);
                if (!called)
                {
                    playerHealth.GetComponent<PlayerHealth>().LoseHealth();
                    called = true;
                }
            }
        }
        else
        {
            ResetTimer();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        time = 180f;
        timerStart = false;
        called = false;
    }
}
