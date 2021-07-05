using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameManager))]
public class CharactersDatabase : MonoBehaviour
{
    public List<Character> Characters;

    private void Awake()
    {
        Characters = Character.GetAllInstances();
    }
    
    public Character RandomCharacter()
    {
        return Characters[Random.Range(0, Characters.Count)];
    }
}