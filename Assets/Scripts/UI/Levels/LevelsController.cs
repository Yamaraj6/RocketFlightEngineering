using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Levels
{
    public class LevelsController : MonoBehaviour
    {
        public GameObject MenuPanel;

        public void StartLevel(string levelSceneName)
        {
            SceneManager.LoadScene(levelSceneName);
        }

        public void BackToMenuPanel()
        {
            MenuPanel.SetActive(true);
            gameObject.SetActive(false);
        }



    }
}