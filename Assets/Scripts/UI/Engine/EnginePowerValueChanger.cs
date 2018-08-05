using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Engine
{
    public class EnginePowerValueChanger : MonoBehaviour
    {
        public Slider EnginePowerSlider;


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
            gameObject.GetComponent<Text>().text = EnginePowerSlider.value.ToString();
            _playerSettingsCollector.CollectSettings(UnitOfWork.EngineNumber, EnginePowerSlider.value);
        }

        private void Start()
        {
            SetValue();
        }



        private void SetValue()
        {
            var enginePower = _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, UnitOfWork.EngineNumber);
            EnginePowerSlider.value = enginePower;
            gameObject.GetComponent<Text>().text = enginePower.ToString();
        }
    }
}