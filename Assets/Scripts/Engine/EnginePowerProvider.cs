using System;
using System.ComponentModel;
using DataContainer;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Engine
{
    public class EnginePowerProvider
    {
        private readonly IContainer<Player> _playerContainer;
        public EnginePowerProvider()
        {
            _playerContainer = PlayerController.PlayerContainer;
        }

        public float ProvidePower(EngineNumber engineNumber)
        {
            return _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber,
                ((int) engineNumber).ToString());
        }
    }
}