using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    public AudioSource footstepsSound;
    private bool isJumping = false;
    private float delay = 2f; // Durée du délai en secondes

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            StartCoroutine(PlayJumpSound());
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && !isJumping)
        {
            if(!footstepsSound.isPlaying)
            {
                footstepsSound.enabled = true;
                footstepsSound.PlayDelayed(delay);
            }
        }
        else
        {
            footstepsSound.enabled = false;
            footstepsSound.Stop();
        }
    }

    IEnumerator PlayJumpSound()
    {
        yield return new WaitForSeconds(delay);
        if(isJumping)
        {
            // Jouer le son de saut ici, si nécessaire
        }
    }
}
