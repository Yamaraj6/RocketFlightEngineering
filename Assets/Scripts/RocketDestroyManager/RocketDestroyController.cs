using UnityEngine;

namespace RocketDestroyManager
{
    public class RocketDestroyController : MonoBehaviour
    {
        public void DestroyRocket(GameObject rocket)
        {
            GameObject.Destroy(rocket);
            //TODO: detroy effects
        }

    }
}
