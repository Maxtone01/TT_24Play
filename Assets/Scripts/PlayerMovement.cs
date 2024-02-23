using Contexts;
using UnityEngine;
public class PlayerMovement: MonoBehaviour
{
    public Rigidbody rigidBody;
    public bool IsPaused => GameContext.Instance.PauseManager.IsPaused;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    public void Update()
    {
        if (IsPaused)
        {
            return;
        }
        
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + -touch.deltaPosition.x * 0.003f);
            }
        }
        rigidBody.transform.Translate(transform.forward * (4f * Time.deltaTime), Space.World);
    }
}