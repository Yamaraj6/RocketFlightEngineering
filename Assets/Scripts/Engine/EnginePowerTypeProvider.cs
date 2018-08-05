using DataContainer;
using Extensions;
using Models;
using PlayerManager;

namespace Engine
{
    public class EnginePowerTypeProvider
    {
        private readonly IContainer<Player> _playerContainer;
        public EnginePowerTypeProvider()
        {
            _playerContainer = PlayerController.PlayerContainer;
        }

        public bool ProvidePowerType(EngineNumber engineNumber)
        {
            return _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber,
                ((int)engineNumber).ToString()).StepPower;
        }
    }
}