using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //init and define the size of the grid: 5 by 5
    public int width = 5, height = 5;
    int[,] grid;
    
    public Transform object1;
    public Transform object2;

    public GameObject eggPrefab1, eggPrefab2, eggPrefab3;

    void Update()
    {
        if (object1 && object2)
        {
            //get the two objects' position and assign them to the Vector2 vars
            Vector2 obj1Pos = object1.position;
            Vector2 obj2Pos = object2.position;

            //swap the positions
            object2.position = obj1Pos;
            object1.position = obj2Pos;
            
            Swapped(object1, object2);

            //reset object 1 and object 2 to null
            object1 = null;
            object2 = null;
        }
    }

    public bool Swapped(Transform object1, Transform object2)
    {
        //if both object 1 and object 2 are true, return true
        return object1 && object2;
    }
    
    
}
