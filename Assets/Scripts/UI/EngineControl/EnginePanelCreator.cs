using UnityEngine;

namespace UI.EngineControl
{
    public class EnginePanelCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _enginePanel;

        public void InstantiatePanel()
        {
            Instantiate(_enginePanel, gameObject.transform.parent);
        }
    }
}