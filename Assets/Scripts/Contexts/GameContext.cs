using Managers;
using UnityEngine;

namespace Contexts
{
    public class GameContext : MonoBehaviour
    {
        public PauseManager PauseManager { get; private set; }

        public static GameContext Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
            {
                Destroy(gameObject);
                Instance = this;
            }
        }

        public void Initialize()
        {
            PauseManager = new PauseManager();
        }
    }
}
