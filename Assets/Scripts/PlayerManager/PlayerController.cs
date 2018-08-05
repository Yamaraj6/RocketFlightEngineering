using DataContainer;
using Models;
using UnityEngine;

namespace PlayerManager
{
    public class PlayerController : MonoBehaviour
    {
        public static IContainer<Player> PlayerContainer { get; set; }
        

        private void Awake()
        {
         //   DontDestroyOnLoad(this.gameObject);
            PlayerContainer = new Container<Player>();

        }

    }
}