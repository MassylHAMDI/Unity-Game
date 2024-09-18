using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Elec_sc : MonoBehaviour
{
    
    private DoorScript doorScript;
    public GameObject Door;
    public AudioSource Elec_file;
    public GameObject textob;
    public KeyCode openButton = KeyCode.E;
    public bool inReach;
    

    void Start()
    {
        inReach = false;
        doorScript = Door.GetComponent<DoorScript> ();
    }

    // Update is called once per frame
    void GetKey(){
		doorScript.keySystem.isUnlock = true;
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            textob.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            textob.SetActive(false);
        }
    }
    void Update()
    {
        
        if(Input.GetKeyDown(openButton) && inReach)
        {
            Elec_file.Play();
            GetKey();
        }
    }


}
