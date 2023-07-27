using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Scene scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a = PlayerPrefs.GetInt("Scene");
        if(scene.id != a)
        {
            transform.Find("GreenOutline").gameObject.SetActive(false);
        }
    }

    public void OnScenePickButton()
    {
        PlayerPrefs.SetInt("Scene", scene.id);

        transform.Find("GreenOutline").gameObject.SetActive(true);


    }
}
