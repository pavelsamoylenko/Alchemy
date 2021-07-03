using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;

    public ItemType Type;
    public ItemLevel Level;

    public static List<T> GetAllInstances<T>() where T : ScriptableObject
    {
        var guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);  //FindAssets uses tags check documentation for more info
        var a = new List<T>();
        for(var i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            var path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a.Add(AssetDatabase.LoadAssetAtPath<T>(path));
        }
 
        return a;
 
    }
}
