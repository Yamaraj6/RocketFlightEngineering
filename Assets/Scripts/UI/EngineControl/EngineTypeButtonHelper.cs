using System.Linq;
using Extensions;
using UnityEngine;

namespace UI.EngineControl
{
    public class EngineTypeButtonHelper : MonoBehaviour
    {
        private void Start()
        {
            var engineSettingsPanel = GameObject.FindGameObjectsWithTag("EngineSettings").FirstOrDefault(f => f.name.Contains("1"));
            engineSettingsPanel.transform.SetActiveAllChildren(true);

        }

        public void ShowProperEngine()
        {
            var engineNumber = gameObject.name.Replace("EngineButton","");
            var engineSettingsPanels = GameObject.FindGameObjectsWithTag("EngineSettings");

            foreach (var panel in engineSettingsPanels)
            {
                panel.transform.SetActiveAllChildren(false);
            }

            
            var properEngineSettingsPanel = engineSettingsPanels.FirstOrDefault(f => f.name.Contains(engineNumber));
            properEngineSettingsPanel.transform.SetActiveAllChildren(true);
        }


    }
}