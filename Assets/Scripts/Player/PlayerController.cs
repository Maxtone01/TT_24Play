using System;
using Contexts;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private static Action OnGameEnd => EventManager.Instance.OnGameEnd;
        [SerializeField]
        private Animator animatorController;

        [SerializeField] private TrailRenderer _trailRenderer;
    
        public bool IsPaused => GameContext.Instance.PauseManager.IsPaused;

        private float _animationSpeed;

        private void Start()
        {
            _animationSpeed = animatorController.speed;
        }

        private void Update()
        {
            animatorController.speed = IsPaused ? 0 : _animationSpeed;
            _trailRenderer.gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 
                -1.66f, transform.localPosition.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("GameOverObject"))
            {
                OnGameEnd?.Invoke();
                GameContext.Instance.PauseManager.SetPause(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Destroyable"))
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
