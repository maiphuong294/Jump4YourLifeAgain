using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] PlayerPrefab;
    void Start()
    {
        int index = PlayerPrefs.GetInt("Character");
        if( index == -1)
        {
            index = Random.Range(0, 5);
        }
        Instantiate(PlayerPrefab[index]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
