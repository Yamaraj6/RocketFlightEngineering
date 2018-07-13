using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Engine
{
    public class EnginePowerValueChanger : MonoBehaviour
    {
        public Slider EnginePowerSlider;

        private void Start()
        {
            gameObject.GetComponent<Text>().text = EnginePowerSlider.value.ToString("0.00");
        }
        public void ChangeValue()
        {
            gameObject.GetComponent<Text>().text = EnginePowerSlider.value.ToString("0.00");
        }
    }
}