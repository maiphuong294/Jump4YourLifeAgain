using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Scene[] SceneData;
    void Start()
    {
        int index = PlayerPrefs.GetInt("Scene");
        if(index == -1)
        {
            index = Random.Range(0, 5);
        }
        Scene a = SceneData[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = a.scene;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
