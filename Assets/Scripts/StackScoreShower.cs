using System.Collections;
using TMPro;
using UnityEngine;

public class StackScoreShower : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.enabled = true;
        Destroy(gameObject, 2f);
    }
}
