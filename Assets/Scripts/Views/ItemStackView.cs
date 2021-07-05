using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStackView : MonoBehaviour
{
    public ItemButton itemButtonPrefab;
    [SerializeField] private GameObject buttonsParent;
    [SerializeField] private SlotsStackView _slotsStackView;

    private List<GameObject> _buttons = new List<GameObject>();
    

    
    public void GenerateItemButtons(List<Item> items)
    {
        Reset();
        foreach (var item in items)
        {
            var button = GenerateButton(item);
            _buttons.Add(button.gameObject);
        }
    }

    private void Reset()
    {
        foreach (var go in _buttons)
        {
            Destroy(go);
        }
        _buttons.Clear();
    }

    private ItemButton GenerateButton(Item item)
    {
        ItemButton button = Instantiate(itemButtonPrefab, buttonsParent.transform, false);
        button.InitializeButton(item);

        button.OnClick += SendItemToSlot;

        button.SetActive(true);

        return button;
    }

    private void SendItemToSlot(Item item)
    {
        _slotsStackView.FillSlot(item);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
