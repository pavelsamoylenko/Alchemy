using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStackViewController : MonoBehaviour
{
    public GameObject itemButtonPrefab;
    public Transform contentParent;

    private SlotsStackViewController _slotsStackViewController;
    private ItemDatabase _itemDatabase;

    private List<GameObject> _buttons = new List<GameObject>();
    
    void Start()
    {
        _itemDatabase = FindObjectOfType<ItemDatabase>();
        _slotsStackViewController = FindObjectOfType<SlotsStackViewController>();
        GenerateItemButtons();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateItemButtons()
    {
        foreach (var item in _itemDatabase.items) GenerateButton(item);
    }

    private void GenerateButton(Item item)
    {
        GameObject button = Instantiate(itemButtonPrefab, itemButtonPrefab.transform.parent, false);
        button.GetComponent<ItemButton>().InitializeButton(item);
        _buttons.Add(button);
        button.SetActive(true);
    }

    public void SendItemToSlot(Item item)
    {
        _slotsStackViewController.FillSlot(item);
    }
}
