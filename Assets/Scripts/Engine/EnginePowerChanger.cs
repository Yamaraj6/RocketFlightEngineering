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
        private IContainer<Player> _playerContainer;

        private void Awake()
        {
            _rocket = GameObject.FindGameObjectWithTag("Rocket");
        }

        private void OnTriggerEnter(Collider other)
        {
            var collisionName = other.gameObject.name;
            if (!collisionName.Contains("Rocket"))
                return;

            var pointNumber = gameObject.name.Replace("CollisionPoint", "");
            if (pointNumber == "1")
                return;

            UnitOfWork.PointNumber = pointNumber;
            SetUpNewEnginesPower(pointNumber);
            Debug.Log($"Setting up engines on {pointNumber}");

        }

        private void SetUpNewEnginesPower(string pointNumber)
        {
            _playerContainer = PlayerController.PlayerContainer;
            var engines = _rocket.GetComponents<RocketEngine>();
        //    var helper = 0;
            var powerDictionary = _playerContainer.Data.LevelEngineSettings.PointSettings[UnitOfWork.LevelNumber]
                .Engine[pointNumber].EnginePower;
            foreach (var engine in engines)
            {
                engine.ForceMultiplier = powerDictionary[((int) engine.EngineNumber).ToString()];
                engine.Duration += 3; //TODO : ogarnac ta wartosc sprytnie jakos
            }

        /*    foreach (var value in _playerContainer.Data.LevelEngineSettings.PointSettings[UnitOfWork.LevelNumber]
                .Engine[pointNumber].EnginePower.Values)
            {
                engines[helper].ForceMultiplier = value;
                engines[helper].Duration += 2;
                helper++;
            }*/
        }
    }
}