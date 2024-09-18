using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject Door;
    public GameObject gameOverPanel;
    private DoorScript doorScript;
    private Timer TimerScript;
    public GameObject TimerManager;
    public AudioSource alarmSound; // AudioSource pour l'alarme
    private int wrongAttempts = 0; // Compteur d'erreurs
    public Text textOB;
    public string answer = "1234";

    //public AudioSource button;
    //public AudioSource correct;
    //public AudioSource wrong;

    public bool animate;


    void Start()
    {
        keypadOB.SetActive(false);
        doorScript = Door.GetComponent<DoorScript> ();
        TimerScript = TimerManager.GetComponent<Timer> ();

    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        //button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            //correct.Play();
            textOB.text = "Right";
            GetKey();
            TimerManager.SetActive(false);
        }
        else
        {
            TriggerTimer();
            wrongAttempts++; // Incrémenter le compteur d'erreurs
            if (wrongAttempts < 2)
            {
                textOB.text = "Wrong, try again";
            }

            else 
            {
                textOB.text = "Wrong, no more attempts";
                TriggerAlarm();
            }
        }


    }

    
    void TriggerTimer()
    {
        TimerManager.SetActive(true);
        
    }

    public void TriggerAlarm()
    {
        if (alarmSound != null)
        {
            alarmSound.Play(); // Jouer le son de l'alarme
            new WaitForSeconds(20f);
            ShowGameOver();
        }
        else
        {
            Debug.LogError("Alarm sound is not set!");
        }
    }
    void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Afficher l'écran de game over
        StopGame();
    }
  
    void StopGame()
    {
        Invoke("QuitGame", 5f); // Quitte le jeu après un délai de 5 secondes
    }

    void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Clear()
    {
        {
            textOB.text = "";
           // button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   	void GetKey(){
		doorScript.keySystem.isUnlock = true;
	}

    public void Update()
    {
        //if (textOB.text == "Right" && animate)
        //{
          //  ANI.SetBool("animate", true);
            //Debug.Log("its open");
        //}



        if(keypadOB.activeInHierarchy)
        {
            player.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    



}
