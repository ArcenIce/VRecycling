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
        Debug.Log("BlackTrashCanCollision");
        // Tente de trouver le composant ScoreValue dans la scène au démarrage
        scoreValue = FindObjectOfType<ScoreValue>();

        // Log une erreur si ScoreValue n'est pas trouvé pour s'assurer que le problème est clair
        if (scoreValue == null)
        {
            Debug.LogError("Impossible de trouver un composant ScoreValue dans la scène.");
        }
        scoreText.enabled = false;
    }

    //Detect collisions between the GameObjects with Colliders attached
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
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == tag)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            if (scoreValue != null) // Assurez-vous que scoreValue n'est pas null avant d'accéder à score
            {
                scoreValue.score += 1;
                
                main.startColor = Color.green;
                scoreText.text = "+1";
                scoreText.color = Color.green;
                SuccessSound.Play();

            }
        }
        else
        {
            main.startColor = Color.red;
            scoreText.text = "-1";
            scoreText.color = Color.red;
            ErrorSound.Play();
        }
        // scoreText.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        scoreText.enabled = true;
        particle.Play();
        Destroy(collision.gameObject);

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
