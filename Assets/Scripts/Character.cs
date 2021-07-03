using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
        public string Name;
        public Sprite Image;
        public string Text;
        
        public static List<Character> GetAllInstances()
        {
                var guids = AssetDatabase.FindAssets("t:"+ typeof(Character).Name);  //FindAssets uses tags check documentation for more info
                var a = new List<Character>();
                for(var i = 0; i < guids.Length; i++)         //probably could get optimized 
                {
                        var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                        a.Add(AssetDatabase.LoadAssetAtPath<Character>(path));
                }
 
                return a;
 
        }
}