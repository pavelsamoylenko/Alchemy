using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDatabase : MonoBehaviour 
{
    public List<Item> items;
    
    
    private void Awake()
    {
        items = Item.GetAllInstances();
        Debug.Log("Items database created. Count: " + items.Count);
    }
    

}
