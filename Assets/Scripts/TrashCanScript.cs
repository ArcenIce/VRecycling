using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BlackTrashCanCollision : MonoBehaviour
{
    private ScoreValue scoreValue; // Changé en privé pour assigner dynamiquement
    public new string tag = null;
    public ParticleSystem particle;

    public Text scoreText;

    public AudioSource SuccessSound;
    public AudioSource ErrorSound;

    public AudioSource FlyingTrashSound;

    void Start()
    {   
        scoreValue = FindObjectOfType<ScoreValue>();

        if (scoreValue == null)
        {
            Debug.LogError("Impossible de trouver un composant ScoreValue dans la scène.");
        }
        scoreText.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        ParticleSystem.MainModule main = particle.main;
        if (collision.gameObject.tag == "Untagged")
        {
            main.startColor = Color.white;
            Destroy(collision.gameObject);
            particle.Play();
            FlyingTrashSound.Play();
            return;
        }
        if (collision.gameObject.tag == tag)
        {
            if (scoreValue != null)
            {
                scoreValue.actuel += 1;
                scoreValue.score += 1;
                
                main.startColor = Color.green;
                scoreText.text = "+1";
                scoreText.color = Color.green;
                SuccessSound.Play();

            }
        }
        else
        {
            scoreValue.actuel += 1;
            main.startColor = Color.red;
            scoreText.text = "-1";
            scoreText.color = Color.red;
            ErrorSound.Play();
        }
        // scoreText.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        scoreText.enabled = true;
        particle.Play();
        Destroy(collision.gameObject);


        // if (actuel >= max)
        // {
        //     SceneManager.LoadScene("Fin");
        //     // Debug.LogWarning($" DEBUGBGUGBUG {actuel}. {max}");
        // }

        // Attendre 1 seconde avant de désactiver le texte
        StartCoroutine(AnimateScoreText());

    }

    private IEnumerator AnimateScoreText()
    {
        float duration = 1.5f; // Durée de l'animation en secondes
        float distanceToMove = 0.5f; // Distance sur l'axe Y que le texte va parcourir
        Vector3 startPosition = scoreText.transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, distanceToMove, 0);

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            scoreText.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Attendre un court instant avant de désactiver le texte
        yield return new WaitForSeconds(0.2f);
        scoreText.enabled = false;
        // Reset la position du texte pour une utilisation future
        scoreText.transform.position = startPosition;
    }
}
