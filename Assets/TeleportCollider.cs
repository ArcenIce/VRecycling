using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(-1, 2, -10);
        collision.rigidbody.velocity = Vector3.zero;
        collision.rigidbody.angularVelocity = Vector3.zero;
    }
}
