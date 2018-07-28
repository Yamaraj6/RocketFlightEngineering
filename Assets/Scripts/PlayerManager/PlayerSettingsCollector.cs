using System.Collections.Generic;
using DataContainer;
using Models;
using UnityEngine;

namespace PlayerManager
{
    public class PlayerSettingsCollector
    {
        private readonly IContainer<Player> _playerContainer;
        public PlayerSettingsCollector()
        {
            _playerContainer = PlayerController.PlayerContainer;
        }

        public void CollectSettings(string engineNumber, float power)
        {
            var levelNumber = UnitOfWork.LevelNumber;// SceneManager.GetActiveScene().name.Replace("Level", "").Replace("Scene", "");
            var pointNumber = UnitOfWork.PointNumber;

            if (_playerContainer.Data.LevelEngineSettings == null)
            {
                _playerContainer.Data.LevelEngineSettings = new LevelEngineSettings()
                {
                    PointSettings = new Dictionary<string, PointSettings>()
                    {
                        {
                            "1", new PointSettings()
                            {
                                Engine = new Dictionary<string, global::Models.Engine>()
                                {
                                    {
                                        "1", new global::Models.Engine()
                                        {
                                            EnginePower = new Dictionary<string, float>()
                                            {
                                                {"1", 10}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            }
            else
            {
                if (_playerContainer.Data.LevelEngineSettings.PointSettings.ContainsKey(levelNumber))
                {
                    if (_playerContainer.Data.LevelEngineSettings.PointSettings[levelNumber].Engine
                        .ContainsKey(pointNumber))
                    {
                        if (_playerContainer.Data.LevelEngineSettings.PointSettings[levelNumber].Engine[pointNumber]
                            .EnginePower.ContainsKey(engineNumber))
                        {
                            _playerContainer.Data.LevelEngineSettings.PointSettings[levelNumber].Engine[pointNumber]
                                .EnginePower[engineNumber] = power;
                        }
                        else
                        {
                            _playerContainer.Data.LevelEngineSettings.PointSettings[levelNumber].Engine[pointNumber]
                                .EnginePower.Add(engineNumber, power);
                        }
                    }
                    else
                    {
                        _playerContainer.Data.LevelEngineSettings.PointSettings[levelNumber].Engine.Add(pointNumber,
                            new global::Models.Engine()
                            {
                                EnginePower = new Dictionary<string, float>()
                                {
                                    {engineNumber, power}
                                }
                            });
                    }
                }
                else
                {
                    _playerContainer.Data.LevelEngineSettings.PointSettings.Add(levelNumber, new PointSettings()
                    {
                        Engine = new Dictionary<string, global::Models.Engine>()
                        {
                            {
                                pointNumber, new global::Models.Engine()
                                {
                                    EnginePower = new Dictionary<string, float>()
                                    {
                                        {engineNumber, power}
                                    }
                                }
                            }
                        }

                    });
                }
            }

            _playerContainer.SaveData();
        }

        //   var enginesData
    }
}