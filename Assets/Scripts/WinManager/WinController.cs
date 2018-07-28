using UnityEngine;

namespace WinManager
{
    public class WinController : MonoBehaviour
    {

        
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

        }

        private void ShowLooseScreen()
        {

        }
    }
}