using UnityEngine;

namespace UI.Menu
{
    public class MenuController : MonoBehaviour
    {
        public GameObject NormalLevelsPanel;
        public void StartNormalMode()
        {
            NormalLevelsPanel.SetActive(true);
            Debug.Log("Starting normal mode. Showing levels:");
            gameObject.SetActive(false);
        }

        public void StartEndlessMode()
        {
            Debug.Log("Not implemented yet.");
        }

        public void ShowRankings()
        {
            Debug.Log("Showing rankings.");
            //tutaj google play services albo moze od unity cos?? do obagadania
       }


    }
}