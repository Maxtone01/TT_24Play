using System;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        EventManager.Instance.OnGameEnd += EnablePanel;
    }
    
    private void OnDestroy()
    {
        EventManager.Instance.OnGameEnd -= EnablePanel;
    }

    private void EnablePanel()
    {
        _gameOverPanel.SetActive(true);
    }
}
