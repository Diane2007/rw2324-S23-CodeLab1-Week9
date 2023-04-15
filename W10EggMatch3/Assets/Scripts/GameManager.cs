using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    //init and define the size of the grid: 4 by 4
    public int width = 4, height = 4;
    int[,] grid;
    
    public Transform object1;
    public Transform object2;

    public GameObject eggPrefab0, eggPrefab1, eggPrefab2;
    public GameObject egg0, egg1, egg2;     //the holder for instantiated eggs
    public GameObject prefabs;
    int randomNum;
    

    void Start()
    {
        //define the grid
        grid = new int[width, height];

        //the array to pull eggs from
        GameObject[] threePrefabs = { eggPrefab0, eggPrefab1, eggPrefab2 };

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                randomNum = Random.Range(0, 3);
                Debug.Log(randomNum);
                grid[x, y] = randomNum;
            }
        }
        InstantiatePrefab();
    }

    void Update()
    {
        //when clicked on two sprites, swap position
        if (object1 && object2)
        {
            //get the two objects' position and assign them to the Vector2 vars
            Vector2 obj1Pos = object1.position;
            Vector2 obj2Pos = object2.position;

            //swap the positions
            object2.position = obj1Pos;
            object1.position = obj2Pos;

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

    void InstantiatePrefab()
    {
        for (var y = 0; y < grid.GetLength(1); y++)
        {
            for (var x = 0; x < grid.GetLength(0); x++)
            {
                switch (grid[x,y])
                {
                    case 0:
                        GameObject obj0 = Instantiate(eggPrefab0,new Vector3(x, y, 0), Quaternion.identity);
                        obj0.transform.parent = prefabs.transform;
                        break;
                    case 1:
                        GameObject obj1 = Instantiate(eggPrefab1,new Vector3(x, y, 0), Quaternion.identity);
                        obj1.transform.parent = prefabs.transform;
                        break;
                    case 2:
                        GameObject obj2 = Instantiate(eggPrefab2,new Vector3(x, y, 0), Quaternion.identity);
                        obj2.transform.parent = prefabs.transform;
                        break;
                    case 3:
                        break;
                }
            }
        }
    }


    }
