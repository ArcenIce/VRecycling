using System;
using UnityEngine;

public class CubeSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 lastPosition;

    void Start()
    {
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
}