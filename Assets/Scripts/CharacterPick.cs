using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPick : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Character charData;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCharacterPickButton()
    {
        PlayerPrefs.SetString("Character", charData.characterName);

    }
}
