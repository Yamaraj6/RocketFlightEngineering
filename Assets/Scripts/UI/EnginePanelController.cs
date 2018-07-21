using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace UI
{
    public class EnginePanelController : MonoBehaviour
    {
        [SerializeField] private List<Vector3> _enginesPosition;
        [SerializeField] private List<AnimationCurve> _engineForce;
        [SerializeField] private GameObject _controlPanel;

        public void Awake()
        {

        }

        private void Start()
        {
            var iterrationNumber = 0;
            foreach (var enginePostion in _enginesPosition)
            {
                var instantiedEmptyChild = Instantiate(_controlPanel, gameObject.transform);
                instantiedEmptyChild.name = $"ControlPanel{iterrationNumber+1}";
                // instantiedEmptyChild.SetActive(true);
                var engineManager = instantiedEmptyChild.AddComponent<EngineManager>();
                engineManager._enginePosition = enginePostion;
                engineManager._force = _engineForce[iterrationNumber];
                iterrationNumber++;
            }
        }

        public void StartEngines()
        {
            BroadcastMessage("SetUpEngine", SendMessageOptions.DontRequireReceiver);
            BroadcastMessage("EngineStart", SendMessageOptions.DontRequireReceiver);

        }
    }



}
