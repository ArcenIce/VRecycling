using UnityEngine;

public class BlackTrashCanCollision : MonoBehaviour
{
    private ScoreValue scoreValue; // Changé en privé pour assigner dynamiquement
    public new string tag = null;

    void Start()
    {
        // Tente de trouver le composant ScoreValue dans la scène au démarrage
        scoreValue = FindObjectOfType<ScoreValue>();

        // Log une erreur si ScoreValue n'est pas trouvé pour s'assurer que le problème est clair
        if (scoreValue == null)
        {
            Debug.LogError("Impossible de trouver un composant ScoreValue dans la scène.");
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == tag)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("C'est le bon tag");
            if (scoreValue != null) // Assurez-vous que scoreValue n'est pas null avant d'accéder à score
            {
                scoreValue.score += 1;
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Debug.Log("Mauvais tag");
            scoreValue.score -= 1;
            Destroy(collision.gameObject);
        }
    }
}
