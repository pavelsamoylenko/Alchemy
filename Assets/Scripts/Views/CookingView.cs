using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

namespace Views
{
    public class CookingView : MonoBehaviour
    {
        [SerializeField] private Slider heatControl;
        [SerializeField] private TextMeshProUGUI temperatureText;
        [SerializeField] private Image FireImage;
        [SerializeField] private GameObject MixButton;
        
        public float CurrentTemperature { get; set; }
        private float _currentVelocity;
        private float _targetTemperature;

        private void Update()
        {
            _targetTemperature = heatControl.value;
            RegulateTemperature();
            FireImageSizeControl();
            UpdateTemperatureText();
        }


        private void RegulateTemperature()
        {
            CurrentTemperature = Mathf.SmoothDamp(CurrentTemperature, _targetTemperature, ref _currentVelocity, 1.5f);

        }
        
        private void FireImageSizeControl()
        {
            var scaleFactor = new Vector3((heatControl.value - 25) / 75 + 1, (heatControl.value - 25) / 75 + 1, 0);
            FireImage.transform.localScale = scaleFactor;
        }
        
        private void UpdateTemperatureText()
        {
            temperatureText.text = $"Temperature: {(int)CurrentTemperature}˚";
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        
        public void ShowCookButton()
        {
            MixButton.SetActive(true);
        }
        public void HideCookButton()
        {
            MixButton.SetActive(false);
        }
    }
}