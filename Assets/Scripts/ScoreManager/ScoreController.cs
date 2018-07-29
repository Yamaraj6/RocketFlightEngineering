using System.ComponentModel;
using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;

namespace ScoreManager
{
    public class ScoreController : MonoBehaviour
    {

        private IContainer<Player> _playerContainer;

        private float _points = 100000;

        public bool StartCounting { get; set; } = false;

        private void Awake()
        {
            _playerContainer = PlayerController.PlayerContainer;
        }

        // Update is called once per frame
        private void Update()
        {
            if(StartCounting)
                _points -= Time.deltaTime*10000;
            Debug.Log(_points);
        }

        public void PointHit()
        {
            _points += 50000;

       /*     _points -= _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, "1")*300;
            _points -= _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, "2") * 300;

            _points -= _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber, "3") * 300;*/

        }
    }
}
