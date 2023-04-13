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

    void Start()
    {

    }
    //
    // bool IsOverGameObject()
    // {
    //     //if currently over game object, return true; otherwise, return false.
    //     return EventSystem.current.IsPointerOverGameObject();
    // }

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
                
                if (GameManager.object1 == null)
                {
                    Debug.Log("Object 1 clicked!");
                    GameManager.object1 = transform;
                }
                //object 2 is empty and is not already selected as object 1
                else if(!GameManager.object2  && GameManager.object1 != transform)
                {
                    Debug.Log("Object 2 clicked!");
                    GameManager.object2 = transform;
                }
            }
        }
    }

    /*
    void SwapPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {

            Debug.Log("hit!");
            if (!isClicked)
            {
                obj1Pos = hit.transform;    //get object 1's transform
                obj1TempPos.transform.position = obj1Pos.
            }
        }
        
        // if (Input.GetMouseButtonDown(0) && IsOverGameObject() && Physics2D.Raycast(ray, hit))
        // {
        //     Debug.Log("Clicked");
        //     
        //
        // }

    }

    void Update()
    {
        SwapPosition();
    }
*/
    
}
