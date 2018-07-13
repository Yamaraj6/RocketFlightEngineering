using Assets.Scripts.DataContainer;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.PlayerManager
{
    public class PlayerController : MonoBehaviour
    {
        public static IContainer<Player> PlayerContainer { get; set; }
        

        private void Awake()
        {
            PlayerContainer = new Container<Player>();

        }

    }
}