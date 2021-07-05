using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingUI : MonoBehaviour
{
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image _receiptImage;
    [SerializeField] private TextMeshProUGUI _characterText;
    [SerializeField] private TextMeshProUGUI _receiptText;
    [SerializeField] private GameObject _cookButton;

    public void SetCookingUI(ReceiptRequest request)
    {
        _cookButton.SetActive(true);
        
        _characterImage.sprite = request.Custumer.Image;
        _characterText.text = request.Custumer.Text + " " + request.Receipt.Name;
        _receiptImage.sprite = request.Receipt.Image;
        _receiptText.text = "Mix ";
        foreach (var item in request.Receipt.Ingredients)
        {
            _receiptText.text += (item.Name + ", ");
        }

        _receiptText.text += ("at a temperature near " + request.Receipt.TargetTemperature);

    }

    public void DisableCook()
    {
        _cookButton.SetActive(false);
    }
}
