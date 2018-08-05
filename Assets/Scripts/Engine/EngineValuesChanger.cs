using System.Linq;
using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using Rocket;
using ScoreManager;
using UnityEngine;

namespace Engine
{
    public class EngineValuesChanger : MonoBehaviour
    {
        private GameObject _rocket;
        private IContainer<Player> _playerContainer;
        private ScoreController _scoreController;


        private void Awake()
        {
            _rocket = GameObject.FindGameObjectWithTag("Rocket");
            _scoreController = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var collisionName = other.gameObject.name;


            if (!collisionName.Contains("Rocket"))
                return;

            _scoreController.PointHit();

            var pointNumber = gameObject.name.Replace("CollisionPoint", "");
            if (pointNumber == "1")
                return;


            UnitOfWork.PointNumber = pointNumber;
            SetUpNewEnginesValues(pointNumber);
            Debug.Log($"Setting up engines on {pointNumber}");

        }

        private void SetUpNewEnginesValues(string pointNumber)
        {
            _playerContainer = PlayerController.PlayerContainer;
            var engines = _rocket.GetComponents<RocketEngine>();
        //    var helper = 0;
            var powerDictionary = _playerContainer.Data.LevelEngineSettings.PointSettings[UnitOfWork.LevelNumber]
                .Engine[pointNumber].EnginePower;
            foreach (var engine in engines)
            {
                engine.ForceMultiplier = powerDictionary[((int) engine.EngineNumber).ToString()].Power;
                engine.Delay = powerDictionary[((int) engine.EngineNumber).ToString()].Delay;
                engine.Duration += 3; //TODO : ogarnac ta wartosc sprytnie jakos
            }

        }
    }
}