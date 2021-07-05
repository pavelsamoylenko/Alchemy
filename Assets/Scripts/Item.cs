using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public enum ItemType 
    {
        Liquid,
        Powder,
        Herb,
        Potion,
        Other
    }
    public enum ItemLevel
    {
        Common,
        Rare,
        Legendary
    }
    
    public string Name;
    public string Description;
    public Sprite Image;

    public ItemType Type;
    public ItemLevel Level;

    public static List<Item> GetAllInstances() 
    {
        return Resources.LoadAll<Item>("ScriptableObjects/").ToList();
 
    }
}
