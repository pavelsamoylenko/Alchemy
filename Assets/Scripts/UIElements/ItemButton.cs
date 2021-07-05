using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public event Action<Item> OnClick;

    [SerializeField]
    private Button _button;
    [SerializeField]
    private TextMeshProUGUI _nameField;
    [SerializeField]
    private Image _image;

    private Item _item;

    public void InitializeButton(Item item)
    {
        _item = item;
        name = item.Name + " Item Button";
        _nameField.text = item.Name;
        _image.sprite = item.Image;

        _button.onClick.AddListener(ClickHandler);
    }

    private void ClickHandler() => OnClick?.Invoke(_item);

    public void SetActive(bool active) => gameObject.SetActive(active);
}
