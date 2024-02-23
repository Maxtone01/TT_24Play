using UnityEngine;

public class Stacker : MonoBehaviour
{
    public Transform _stackPosition;
    [SerializeField]
    StackScoreShower _scoreShower;
    [SerializeField]
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StackCubeUnderParent(Collision cube)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        cube.transform.position = new Vector3(_stackPosition.position.x, _stackPosition.position.y, _stackPosition.position.z);
        cube.gameObject.AddComponent<ObjectMovement>();
        cube.gameObject.AddComponent<CubeCollisionDetector>()._stacker = this;
        cube.gameObject.transform.parent = null;
        ShowScore();
        animator.Play("Jumping");
    }

    private void ShowScore()
    {
        Instantiate(_scoreShower.gameObject, new Vector3(transform.position.x, transform.position.y, 
            transform.position.z + 0.5f), Quaternion.Euler(0, 90, 0));
    }
}
