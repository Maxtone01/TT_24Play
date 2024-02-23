using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + -4.5f, transform.position.y, transform.position.z);
    }
}
