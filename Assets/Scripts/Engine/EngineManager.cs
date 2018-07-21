using System.Linq;
using DataContainer;
using Extensions;
using PlayerManager;
using Rocket;
using UnityEngine;
using UnityEngine.UI;

namespace Engine
{
    public class EngineManager : MonoBehaviour
    {
        public Vector3 _enginePosition = new Vector3(0, 0, 0);

        public AnimationCurve _force;


        private UnitOfWork _unitOfWork;
        private GameObject _rocket;
        private RocketEngine _rocketEngine;

        private void Awake()
        {
            _unitOfWork = GameObject.FindGameObjectWithTag("UnitOfWork").GetComponent<UnitOfWork>();
        }
        private void Start()
        {
            _rocket = GameObject.FindGameObjectWithTag("Rocket");
            if (_unitOfWork.PointNumber != "1")
            {
                return;
            }

            Time.timeScale = 0;
            _rocketEngine = _rocket.AddComponent<RocketEngine>();
            _rocketEngine.EnginePosition = _enginePosition;
            _rocketEngine.enabled = false;


        }

        public void SetUpEngine()
        {
            transform.SetActiveAllChildren(true);

            if (_unitOfWork.PointNumber != "1")
            {
                SaveSettingsOnly();
                return;
            }

            _rocketEngine.Force = _force;
            float outValue = 0;
             var succeed=
                float.TryParse(gameObject.GetComponentsInChildren<Text>().FirstOrDefault(f => f.name == "Value")?.text,
                    out outValue);
            if (succeed)
                _rocketEngine.ForceMultiplier = outValue;
            else
                _rocketEngine.ForceMultiplier = 0;


            var engineNumber = gameObject.name.Replace("ControlPanel", "");
            GameObject.FindGameObjectWithTag("Rocket").GetComponent<PlayerSettingsCollector>().CollectSettings(engineNumber, outValue, _unitOfWork);
        }

        private void SaveSettingsOnly()
        {
            float outValue = 0;
            float.TryParse(gameObject.GetComponentsInChildren<Text>().FirstOrDefault(f => f.name == "Value")?.text,
                    out outValue);

            var engineNumber = gameObject.name.Replace("ControlPanel", "");
            GameObject.FindGameObjectWithTag("Rocket").GetComponent<PlayerSettingsCollector>().CollectSettings(engineNumber, outValue, _unitOfWork);

        }

        public void EngineStart()
        {
         //   _rocketEngine.PrepareToStart();
            if (_unitOfWork.PointNumber != "1")
                return;

            _rocketEngine.enabled = true;
            Time.timeScale = 1;
        }
    }
}