using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlaskUI : MonoBehaviour
{
    public Slider heatControl;
    public TextMeshProUGUI temperatureText;
    public Image FireImage;

    public float CurrentTemperature { get; set; }

    private float _defaultTemperature = 25;
    private float _targetTemperature;

    private float _currentVelocity;



    // Start is called before the first frame update
    void Start()
    {
        CurrentTemperature = _defaultTemperature;
        _targetTemperature = heatControl.value;
    }

    // Update is called once per frame
    void Update()
    {

        _targetTemperature = heatControl.value;
        RegulateTemperature();
        FireImageSizeControl();
        SendText();
    }

    private void RegulateTemperature()
    {
        CurrentTemperature = Mathf.SmoothDamp(CurrentTemperature, _targetTemperature, ref _currentVelocity, 2f);

    }

    private void FireImageSizeControl()
    {
        var scaleFactor = new Vector3(3f * (heatControl.value - 25) / 75 + 1, (heatControl.value - 25) / 75 + 1, 0);
        FireImage.transform.localScale = scaleFactor;
    }

    private void SendText()
    {
        temperatureText.text = $"Temperature: {(int)CurrentTemperature}˚";
    }


}
