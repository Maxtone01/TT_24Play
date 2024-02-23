using System;
using Contexts;
using UnityEngine;

public class CubeCollisionDetector : MonoBehaviour
{
    public Stacker _stacker;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.tag = "Uncollectable";
            _stacker.StackCubeUnderParent(collision);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject.GetComponent<PlayerMovement>());
        }
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Destroyable"))
        // {
        //     Destroy(gameObject);
        // }
    }
}
