using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "character")]
public class Character : ScriptableObject
{

    public string characterName;

    public Sprite head;
    public Sprite headMono;

    public Sprite body;
    public Sprite leftHand;
    public Sprite rightHand;
    public Sprite leftFoot;
    public Sprite rightFoot;
    public Sprite tail;

    public Sprite full;

   
}
