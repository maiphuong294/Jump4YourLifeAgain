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
        string s = PlayerPrefs.GetString("Scene");
        if(scene.sceneName != s)
        {
            transform.Find("GreenOutline").gameObject.SetActive(false);
        }
    }

    public void OnScenePickButton()
    {
        PlayerPrefs.SetString("Scene", scene.sceneName);

        transform.Find("GreenOutline").gameObject.SetActive(true);


    }
}
