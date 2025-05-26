using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            PlaySound();
            hasPlayed = true;
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}