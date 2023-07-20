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
        string s = PlayerPrefs.GetString("Character");

        if (charData.characterName != s)
        {
            transform.Find("GreenOutline").gameObject.SetActive(false);
            transform.Find("GreenTick").gameObject.SetActive(false);
        }
    }

    public void OnCharacterPickButton()
    {

        PlayerPrefs.SetString("Character", charData.characterName);

        transform.Find("GreenOutline").gameObject.SetActive(true);
        transform.Find("GreenTick").gameObject.SetActive(true);
    }
}
