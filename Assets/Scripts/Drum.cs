using System;
using UnityEngine;

public class Drum : MonoBehaviour
{
    public AudioSource DrumSound;
    public void OnTriggerEnter(Collider other)
    {
        DrumSound.Play();
        Debug.Log(other.name + " has entered the trigger");
    }

    // Utilisez cette méthode si vous n'utilisez pas de Trigger
    public void OnCollisionEnter(Collision collision)
    {
        DrumSound.Play();
        Debug.Log(collision.collider.name + " has collided with the object");
    }
}
