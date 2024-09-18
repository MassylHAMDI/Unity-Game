using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject keypadOB;
    public GameObject keypadText;

    public bool inReach;

    // Définissez ici la touche pour ouvrir le clavier
    public KeyCode openButton = KeyCode.E; // Par défaut, cela utilise la touche E

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            keypadText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            keypadText.SetActive(false);
        }
    }

    void Update()
    {
        
        if(Input.GetKeyDown(openButton) && inReach)
        {
            keypadOB.SetActive(true);
            keypadText.SetActive(false);
        }
    }
}
