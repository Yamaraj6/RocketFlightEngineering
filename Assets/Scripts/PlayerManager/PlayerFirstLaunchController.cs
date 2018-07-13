using System;
using System.Linq;
using Assets.Scripts.DataContainer;
using Assets.Scripts.FirstLaunch;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace Assets.Scripts.PlayerManager
{
    public class PlayerFirstLaunchController : MonoBehaviour
    {
        private IFirstLaunchChecker _firstLaunchChecker;
        private IContainer<Player> _playerContainer;

        public GameObject FirstLaunchPanel;
        public GameObject MenuPanel;

        private void Start()
        {

            _firstLaunchChecker = new FirstLaunchChecker();

            if (_firstLaunchChecker.IsFirstLaunch == false)
            {
                Debug.Log("Not a first launch, processing further.");
                ProcessFurther();
                return;
            }

            Debug.Log("Running first launch screen.");

            FirstLaunchPanel.SetActive(true);
        }

        public void SetPlayer()
        {
            _playerContainer = PlayerController.PlayerContainer;
            _playerContainer.Data.Name = FirstLaunchPanel.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>().Last().text;
            _playerContainer.Data.FirstLogDate = DateTime.Now;
            _playerContainer.Data.LastLogDate = DateTime.Now;
            _playerContainer.SaveData();

            Destroy(FirstLaunchPanel);
            _firstLaunchChecker.CompleteFirstLaunch();
            Debug.Log("First launch completed succesfully. Proccesing to game.");
            ProcessFurther();

        }


        private void ProcessFurther()
        {
            MenuPanel.SetActive(true);
        }






    }
}