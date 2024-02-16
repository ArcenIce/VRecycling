using System;
using UnityEngine;

public class CubeSoundManager : MonoBehaviour
{
    public AudioSource audioSourceStone;
    public AudioSource audioSourceGrass;

    private AudioSource audioSource;
    private Vector3 lastPosition;

    private String Col;

    void Start()
    {
        audioSourceGrass = GetComponent<AudioSource>();
        audioSourceStone = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Vérifie si l'objet s'est déplacé
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f) // Vous pouvez ajuster la sensibilité ici
        {
            // Joue le son s'il n'est pas déjà en train de jouer
            if (!audioSource.isPlaying)
            {
                if (Col == "Small Terrrain 1"){
                   audioSource.clip = audioSourceGrass.clip;
                } else {
                    audioSource.clip = audioSourceStone.clip;
                }
                audioSource.Play();
            }
        }
        else
        {
            // Optionnel : arrête le son si l'objet ne bouge plus
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Mise à jour de la dernière position pour la prochaine vérification
        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(Col);
        if (other.tag == "Small Terrrain 1"){
            other.tag = Col;
        } else {
            other.tag = Col;
        }
    }

}
