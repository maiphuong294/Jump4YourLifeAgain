using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        int a = PlayerPrefs.GetInt("Character");

        if (charData.id != a)
        {
            transform.Find("GreenOutline").gameObject.SetActive(false);
            transform.Find("GreenTick").gameObject.SetActive(false);
        }
    }

    public void OnCharacterPickButton()
    {

        PlayerPrefs.SetInt("Character", charData.id);

        GreenTick();

        updateCharacterViewDemo();
        updateCharacterButton();
       
    }

    public void updateCharacterButton()
    {
        //update button o menu

        Sprite a = transform.Find("Head").GetComponent<Image>().sprite;

        GameObject charButton = GameObject.Find("Character Button");
        charButton.transform.Find("Character Icon").gameObject.GetComponent<Image>().sprite = a;
    }

    public void updateCharacterViewDemo()
    {
        //update con full body dung tuong trung
        GameObject character = GameObject.Find("Character View");
        character.GetComponent<Image>().sprite = charData.full;

        //update character name
        GameObject characterName = GameObject.Find("Character Name");
        characterName.GetComponent<TextMeshProUGUI>().text = charData.name;
    }

    public void GreenTick()
    {
        transform.Find("GreenOutline").gameObject.SetActive(true);
        transform.Find("GreenTick").gameObject.SetActive(true);
    }
    
    
}
