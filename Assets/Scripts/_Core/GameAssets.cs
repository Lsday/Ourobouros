using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    public GameObject headPrefab;
    public GameObject bonePrefab;
    public GameObject asteroid;
    public GameObject fruitPrefab;

    public Sprite dragonBase, dragonOpenJaw;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


}
