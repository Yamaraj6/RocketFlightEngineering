using UnityEngine;

namespace WinManager
{
    public class WinController : MonoBehaviour
    {
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _looseScreen;
        
        public void ProcessLevelEnding(bool succeded)
        {
            if (succeded)
            {
                ShowWinScreen();
            }
            else
            {
                ShowLooseScreen();
            }
        }

        private void ShowWinScreen()
        {
            _winScreen.SetActive(true);
        }

        private void ShowLooseScreen()
        {
            _looseScreen.SetActive(true);
        }
    }
}