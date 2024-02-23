using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public Action OnGameEnd;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
            Instance = this;
        }
    }
}