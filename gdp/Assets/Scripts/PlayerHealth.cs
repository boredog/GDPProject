using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] health;
    int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        lives = health.Length;
    }

    public void LoseHealth()
    {
        lives -= 1;
        if (lives < 1)
        {
            Destroy(health[0].gameObject);
        }
        if (lives < 2)
        {
            Destroy(health[1].gameObject);
        }
        if (lives < 3)
        {
            Destroy(health[2].gameObject);
        }
        if (lives < 0)
        {
            Debug.Log("Shine");
        }
    }

    private void Update()
    {
        Debug.Log(lives);
    }
}