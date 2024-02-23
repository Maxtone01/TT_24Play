using System;
using Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] RectTransform _startMenu;
    [SerializeField] private ParticleSystem warpEffect;

    public PauseManager PauseManager => GameContext.Instance.PauseManager;

    public void Start()
    {
        GameContext.Instance.Initialize();
        PauseManager.SetPause(true);
        warpEffect.Pause(PauseManager.IsPaused);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        _startMenu.gameObject.SetActive(false);
        GameContext.Instance.PauseManager.SetPause(false);
        warpEffect.Play(!PauseManager.IsPaused);
    }
}
