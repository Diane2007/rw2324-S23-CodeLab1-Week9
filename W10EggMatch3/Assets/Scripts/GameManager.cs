using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Transform object1;
    public static Transform object2;

    void Update()
    {
        if (object1 && object2)
        {
            Vector2 obj1Pos = object1.position;
            Vector2 obj2Pos = object2.position;

            object2.position = obj1Pos;
            object1.position = obj2Pos;

            object1 = null;
            object2 = null;
        }
    }
}
