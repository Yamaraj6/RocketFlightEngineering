using System.Linq;
using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using Rocket;
using UnityEngine;

namespace Engine
{
    public class EnginePowerChanger : MonoBehaviour
    {
        private GameObject _rocket;
        private UnitOfWork _unitOfWork;
        private IContainer<Player> _playerContainer;

        private void Awake()
        {
            _rocket = GameObject.FindGameObjectWithTag("Rocket");
            _unitOfWork = GameObject.FindGameObjectWithTag("UnitOfWork").GetComponent<UnitOfWork>();
            _playerContainer = PlayerController.PlayerContainer;
        }

        private void OnTriggerEnter(Collider other)
        {
            var collisionName = other.gameObject.name;
            if (!collisionName.Contains("Rocket"))
                return;

            var pointNumber = gameObject.name.Replace("CollisionPoint", "");

            SetUpNewEnginesPower(pointNumber);
            Debug.Log($"Setting up engines on {pointNumber}");

        }

        private void SetUpNewEnginesPower(string pointNumber)
        {
            var engines = _rocket.GetComponents<RocketEngine>();
            var helper = 0;
            foreach (var value in _playerContainer.Data.LevelEngineSettings.PointSettings[_unitOfWork.LevelNumber]
                .Engine[pointNumber].EnginePower.Values)
            {
                engines[helper].ForceMultiplier = value;
                engines[helper].Duration += 2;
                helper++;
            }
        }
    }
}