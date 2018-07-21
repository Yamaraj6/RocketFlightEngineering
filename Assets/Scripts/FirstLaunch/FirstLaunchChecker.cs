using UnityEngine;

namespace FirstLaunch
{
    public interface IFirstLaunchChecker
    {
        bool IsFirstLaunch { get; }
        void CompleteFirstLaunch();
    }
    public class FirstLaunchChecker : IFirstLaunchChecker
    {
        public bool IsFirstLaunch { get; private set; } = true;
        private readonly string _firstLaunchKey = "firstlaunch";
        /// <summary>
        /// 0 - first launch
        /// 1 - next launches
        /// </summary>
        public FirstLaunchChecker()
        {
            PlayerPrefs.DeleteAll(); //do testow

            IsFirstLaunch = PlayerPrefs.GetInt(_firstLaunchKey, 0) == 0;
        }

        public void CompleteFirstLaunch()
        {
            PlayerPrefs.SetInt(_firstLaunchKey, 1);
        }

    }
}