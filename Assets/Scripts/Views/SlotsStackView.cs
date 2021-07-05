using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlotsStackView : MonoBehaviour
{
    
    public GameObject slotButtonPrefab;

    [HideInInspector]
    public List<Item> UserItemsSet = new List<Item>();
    private Receipt _currentReceipt;

    public List<GameObject> _slotsGO = new List<GameObject>();

    
    public void SetReceipt(Receipt receipt)
    {
        
        _currentReceipt = receipt;
        var itemsSequence = _currentReceipt.Ingredients;
        foreach (var item in itemsSequence)
        {
            GenerateSlot(item);
        }
        RefreshUserItems();
    }
    
    public void FillSlot(Item item)
    {
        var itemSequence = _currentReceipt.Ingredients;
        //if (!itemSequence.Contains(item)) return;
        foreach (var slotGO in _slotsGO)
        {
            if (!slotGO.GetComponent<SlotButton>().isFilled())
            {
                var slot = slotGO.GetComponent<SlotButton>();
                slot.Item = item;
                slot.Fill();
                break;
            }
        }
        RefreshUserItems();
    }

    public void RefreshUserItems()
    {
        UserItemsSet.Clear();
        foreach (var slotGO in _slotsGO)
        {
            var slot = slotGO.GetComponent<SlotButton>();
            if (slot.isFilled())
            {
                UserItemsSet.Add(slot.Item);
            }
        }
    }
    private void GenerateSlot(Item item)
    {
        GameObject button = Instantiate(slotButtonPrefab, this.transform, false);
        button.name = item.Name + " Slot Button";
        button.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
        _slotsGO.Add(button);
        button.SetActive(true);
        button.GetComponent<SlotButton>().Reset();
    }

    public void Reset()
    {
        foreach (var go in _slotsGO)
        {
            Destroy(go);
        }
        _slotsGO.Clear();
    }
    public void RefreshSlots()
    {
        Reset();
        var itemsSequence = _currentReceipt.Ingredients;
        foreach (var item in itemsSequence)
        {
            GenerateSlot(item);
        }
        RefreshUserItems();
    }
    
}
