using System;
using System.Linq;
using Assets.Scripts.Rocket;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

namespace Assets.Scripts.Engine
{
    public class EngineManager : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _enginePosition = new Vector3(0, 0, 0);

        [SerializeField] private AnimationCurve _force;

        private GameObject _rocket;
        private RocketEngine _rocketEngine;

        private void Start()
        {
            Time.timeScale = 0;
            _rocket = GameObject.FindGameObjectWithTag("Rocket");
            _rocketEngine = _rocket.AddComponent<RocketEngine>();
            _rocketEngine.EnginePosition = _enginePosition;
            _rocketEngine.enabled = false;

        }

        public void SetUpEngine()
        {
            _rocketEngine.ForceMultiplier = float.Parse(gameObject.GetComponentsInChildren<Text>().FirstOrDefault(f => f.name == "Value")?.text);
            _rocketEngine.Force = _force;
        }

        public void EngineStart()
        {
            _rocketEngine.PrepareToStart();
            _rocketEngine.enabled = true;
            Time.timeScale = 1;

        }
    }
}