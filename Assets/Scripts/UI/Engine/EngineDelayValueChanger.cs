using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Engine
{
    public class EngineDelayValueChanger : MonoBehaviour
    {
        public Slider EngineDurationSlider;


        private IContainer<Player> _playerContainer;
        private PlayerSettingsCollector _playerSettingsCollector;
        private void Awake()
        {
            _playerContainer = PlayerController.PlayerContainer;
            _playerSettingsCollector = new PlayerSettingsCollector();

        }
        public void LoadProperEngineValue()
        {
            SetValue();
        }

        private void OnEnable()
        {
            SetValue();
        }

        public void ChangeValue()
        {
            gameObject.GetComponent<Text>().text = EngineDurationSlider.value.ToString("0.00");
       //     EngineDurationSlider.onValueChanged();
        }


        public void SaveValue()
        {
            _playerSettingsCollector.CollectDurationSettings(UnitOfWork.EngineNumber, EngineDurationSlider.value);

        }

        private void Start()
        {
            SetValue();
        }



        private void SetValue()
        {
            var engineDelay = _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, UnitOfWork.EngineNumber);
            EngineDurationSlider.value = engineDelay.Delay;
            gameObject.GetComponent<Text>().text = engineDelay.Delay.ToString("0.00");
        }
    }
}