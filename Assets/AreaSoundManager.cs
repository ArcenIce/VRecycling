using UnityEngine;

public class AmbianceZone : MonoBehaviour
{
    public Component audioComponent;
    public Component ambianceZone;
    private AudioSource audioSource;
    private AudioSource ambianceSource;

    void Start()
    {
        audioSource = audioComponent.GetComponent<AudioSource>();
        ambianceSource = ambianceZone.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = false;
            ambianceSource.mute = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = true;
            ambianceSource.mute = true;
        }
    }
}
