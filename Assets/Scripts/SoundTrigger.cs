using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource musicSource; 
    private bool inZone = false;
    public string PlayerTag = "Player"; 

    void Start()
    {
        if(musicSource == null)
            musicSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Joue la musique seulement si le joueur est dans la zone et que la musique ne joue pas déjà
        if (inZone && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
        // Arrête la musique si le joueur quitte la zone
        else if (!inZone && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter in zone: " + other.tag);
        if (other.tag != PlayerTag)
            return;

        inZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit from zone: " + other.tag);
        if (other.tag != PlayerTag)
            return;

        inZone = false;
    }
}
