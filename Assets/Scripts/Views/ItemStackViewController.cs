using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStackViewController : MonoBehaviour
{
    public ItemButton itemButtonPrefab;
    public Transform contentParent;

    private SlotsStackViewController _slotsStackViewController;
    private ItemDatabase _itemDatabase;

    private List<ItemButton> _buttons = new List<ItemButton>();

    private void Start()
    {
        _itemDatabase = FindObjectOfType<ItemDatabase>();
        _slotsStackViewController = FindObjectOfType<SlotsStackViewController>();
        GenerateItemButtons();
    }

    private void GenerateItemButtons()
    {
        foreach (var item in _itemDatabase.items)
        {
            var button = GenerateButton(item);
            _buttons.Add(button);
        }
    }

    private ItemButton GenerateButton(Item item)
    {
        ItemButton button = Instantiate(itemButtonPrefab, itemButtonPrefab.transform.parent, false);
        button.InitializeButton(item);

        button.OnClick += SendItemToSlot;

        button.SetActive(true);

        return button;
    }

    private void SendItemToSlot(Item item)
    {
        _slotsStackViewController.FillSlot(item);
    }
}
