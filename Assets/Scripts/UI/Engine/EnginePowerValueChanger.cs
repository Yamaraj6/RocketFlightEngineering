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
        private UnitOfWork _unitOfWork;

        private void Awake()
        {
            _playerContainer = PlayerController.PlayerContainer;
            _unitOfWork = GameObject.FindGameObjectWithTag("UnitOfWork").GetComponent<UnitOfWork>();
        }
        private void Start()
        {
            var engineNumber = gameObject.transform.parent.transform.parent.name.Replace("ControlPanel", "");
            var enginePower = _playerContainer.Data.LevelEngineSettings.GetEngineValue(_unitOfWork.LevelNumber,
                _unitOfWork.PointNumber, engineNumber);
            gameObject.transform.parent.GetComponent<Slider>().value = enginePower;
            gameObject.GetComponent<Text>().text = enginePower.ToString("0.00");
        }
        public void ChangeValue()
        {
            gameObject.GetComponent<Text>().text = EnginePowerSlider.value.ToString("0.00");
        }
    }
}