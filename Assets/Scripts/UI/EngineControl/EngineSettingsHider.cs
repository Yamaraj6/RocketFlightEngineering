using UnityEngine;

namespace UI.EngineControl
{
    public class EngineSettingsHider : MonoBehaviour
    {
        private GameObject _engineSettingsLayout;

        private void Awake()
        {
            _engineSettingsLayout = GameObject.FindGameObjectWithTag("EngineSettingsLayout");
        }

        public void ShowEngineSettingsLayout()
        {
            _engineSettingsLayout.SetActive(true);
        }

        public void HideEngineSettingsLayout()
        {
            _engineSettingsLayout.SetActive(false);
        }
    }
}