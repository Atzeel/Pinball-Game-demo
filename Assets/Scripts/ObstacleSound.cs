using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource audioSource;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(sounds.Length == 0) return;
        
        int index = Random.Range(0, sounds.Length);
        AudioClip chosenSound = sounds[index];

        if (chosenSound != null)
        {
            audioSource.PlayOneShot(chosenSound);
        }

    }

}
