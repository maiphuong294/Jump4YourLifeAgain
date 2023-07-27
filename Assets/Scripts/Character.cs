using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "character")]
public class Character : ScriptableObject
{
    public int id;
    public string characterName;
    
    public GameObject prefab;
    public Sprite head;
    public Sprite headMono;

    public Sprite full;
    public Sprite fullMono;
    



}
