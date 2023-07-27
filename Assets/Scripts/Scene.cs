using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "scene")]
public class Scene : ScriptableObject
{
    public int id;
    public string sceneName;
    public Sprite scene;
}
