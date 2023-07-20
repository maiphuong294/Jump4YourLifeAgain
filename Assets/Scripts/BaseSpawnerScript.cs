using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerScript : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject BasePrefab;
    public GameObject FirstBase;
    public float SpawnPosY;
    public float BaseToBase; //khoang cach giua 2 base
    public float timer;
    public float countBase;

    //public List<Base> allCurrentBase;
    // Start is called before the first frame update

    void Start()
    {
      
        SpawnPosY = FirstBase.transform.position.y - BaseToBase;
        countBase = 0f;
        BaseToBase = 3.0f;

       
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnPosY > MainCamera.transform.position.y - 10.0f)
        {
            countBase += 1.0f;
            SpawnPosY -= BaseToBase;
            SpawnBase();
        }
       
    }

    void SpawnBase()
    {
        Instantiate(BasePrefab, new Vector3(Random.Range(-1.8f, 1.8f), SpawnPosY, 0f) , Quaternion.identity);
        //allCurrentBase.Insert(go);
    }



}
