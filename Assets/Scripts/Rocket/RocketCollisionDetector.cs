using RocketDestroyManager;
using UnityEngine;
using WinManager;

namespace Rocket
{
    public class RocketCollisionDetector : MonoBehaviour
    {
        [SerializeField] private WinController _winController;
        [SerializeField] private RocketDestroyController _rocketDestroyController;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                _winController.ProcessLevelEnding(true);
            }
            else if (other.gameObject.CompareTag("Respawn"))
            {

            }
    /*        else
            {
                _rocketDestroyController.DestroyRocket(gameObject);
                _winController.ProcessLevelEnding(false);
            }*/
        }
    }
}
