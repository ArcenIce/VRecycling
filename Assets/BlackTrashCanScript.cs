using UnityEngine;

public class BlackTrashCanCollision : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "BlackTrash")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("C'est le bon tag");
        }
        else
        {
            Debug.Log("Mauvais tag");
        }
        Destroy(collision.gameObject);
    }
}