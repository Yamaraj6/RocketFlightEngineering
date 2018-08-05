using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Engine
{
    public class EnginePowerTypeValueChanger : MonoBehaviour
    {
        public Toggle EnginePowerTypeToggle;

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


        public void SaveValue()
        {
            _playerSettingsCollector.CollectPowerTypeSettings(UnitOfWork.EngineNumber, EnginePowerTypeToggle.isOn);

        }

        private void Start()
        {
            SetValue();
        }



        private void SetValue()
        {
            var engineValues = _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, UnitOfWork.EngineNumber);
            EnginePowerTypeToggle.isOn = engineValues.StepPower;
        }
    }
}