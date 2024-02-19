using UnityEngine;

public class AmbianceZone : MonoBehaviour
{
    public Component audioComponent;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = audioComponent.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = true;
        }
    }
}
