using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Phases { BEFOREINSPECTION,INSPECTIONPHASE, AFTERINSPECTION, DEFEAT }
public class Gameplay : MonoBehaviour
{
    
    //public GameObject playerPrefab;
    //public GameObject emailPrefab;

    public GameObject emailPrefab;
    public GameObject emailDemo;

    public bool allowed;

    public Phases phase;

    public bool isDead;

    public Text gameOverText;

    private void Start()
    {
        gameOverText.enabled = false;
        isDead = false;
        allowed = false;
        phase = Phases.BEFOREINSPECTION;
        Debug.Log("Now before inspection");
    }

    private void Update()
    {
        //if (lifeScript.life == 0)
        //{
        //    isDead = true;
        //    GameOver();
        //}
    }

    public IEnumerator EmailEncounter() //for getting into an encounter with an email, should initiate the inspection phase.
                                //should switch to After Inspection phase after time has passed, or if player chooses an option
    {
        phase = Phases.INSPECTIONPHASE;
        emailDemo = GameObject.FindGameObjectWithTag("Email");
        emailDemo.SetActive(true);
        Debug.Log("Now is Inspection Phase!");
        Debug.Log(emailDemo.GetComponent<EmailClass>().IsVirus); //For checking bool
        yield return new WaitForSeconds(5f);
        StartCoroutine(AfterEmail());
    }

    IEnumerator AfterEmail() //for the after inspection phase. need to check if email was a virus. If yes, reduce life. if no, do nothing. Continue either way,
                            //unless if life reaches 0
    {
        phase = Phases.AFTERINSPECTION;

        emailDemo.GetComponent<EmailClass>().Allowed = false; //sets the boolean back to false by default
        Destroy(emailDemo);

        //if (lifeScript.life == 0)
        //{
          //  phase = Phases.DEFEAT;
            //Debug.Log("died");
        //}
        //else
        //{
          //  Debug.Log("Continuing game, back to Before Inspection Phase");
            yield return new WaitForSeconds(5f);
            BeforeNewEmail();
        //}   
    }

    void BeforeNewEmail()
    {
        phase = Phases.BEFOREINSPECTION;
        Debug.Log("Now waiting for new Email");
    }

    void GameOver()
    {
        Time.timeScale = 0.2f;
        Invoke("ReloadScene", 0.4f);
    }
    void ReloadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BringUpEmail()
    {
        Debug.Log("You have clicked the icon");
        Instantiate(emailPrefab, transform.position, transform.rotation);
        StartCoroutine(EmailEncounter());
    }

    
}
