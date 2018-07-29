using RocketDestroyManager;
using UnityEngine;
using WinManager;

namespace Rocket
{
    public class RocketCollisionDetector : MonoBehaviour
    {
        [SerializeField] private WinController _winController;
        [SerializeField] private RocketDestroyController _rocketDestroyController;

        private bool _isWon = false;
        private void OnCollisionEnter(Collision other)
        {
            if (_isWon)
                return;
            
            if (other.gameObject.CompareTag("World"))
            {
                _rocketDestroyController.DestroyRocket(gameObject);
                _winController.ProcessLevelEnding(false);
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                _isWon = true;
                _winController.ProcessLevelEnding(true);
            }            
        }
    }
}

