using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapPlaceScript : MonoBehaviour
{
    Vector3 objectPos;

    public GameObject highlightCircle;      //init the highlight circle around the gameObject

    void Start()
    {
        //default: the highlight circle is not visible
        highlightCircle.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked!");
            
            //when the mouse is over the gameObject and left key is clicked, show the highlight circle
            highlightCircle.SetActive(true);
            
            //if we haven't assigned a value for Transform object 1 yet
            if (GameManager.instance.object1 == null)
            {
                Debug.Log("Object 1 clicked!");
                //the transform of the current gameObject is assigned to object1
                GameManager.instance.object1 = transform;
            }
            
            //if object 1 is already assigned but object 2 is empty
            //and the current gameObject's transform is not the same as object 1
            //(basically avoid clicking on one gameObject twice)
            else if(!GameManager.instance.object2  && GameManager.instance.object1 != transform)
            {
                Debug.Log("Object 2 clicked!");
                //the transform of the current gameObject is assigned to object2
                GameManager.instance.object2 = transform;
            }
        }
    }

    void Update()
    {
        //if object1 and object2 from GameManager are both true
        if (GameManager.instance.Swapped(GameManager.instance.object1, GameManager.instance.object2))
        {
            //disable the highlight circle gameObject
            highlightCircle.SetActive(false);
        }
    }
}
