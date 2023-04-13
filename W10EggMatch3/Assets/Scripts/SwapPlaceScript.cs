using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapPlaceScript : MonoBehaviour
{
    Vector3 objectPos;
    bool enterCol;
    bool isClicked;       //whether we have clicked on obj1 or not

    void OnMouseEnter()
    {
        Debug.Log("Entered!");
        enterCol = true;
    }

    void OnMouseExit()
    {
        enterCol = false;
    }

    void Update()
    {
        if(enterCol)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked!");
                
                if (GameManager.instance.object1 == null)
                {
                    Debug.Log("Object 1 clicked!");
                    GameManager.instance.object1 = transform;
                }
                //object 2 is empty and is not already selected as object 1
                else if(!GameManager.instance.object2  && GameManager.instance.object1 != transform)
                {
                    Debug.Log("Object 2 clicked!");
                    GameManager.instance.object2 = transform;
                }
            }
        }
    }

    
}
