using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPoint : MonoBehaviour
{
    // Put on Every Contact Point to determine if Contact Point is taken.

    public bool isTaken;
    public int childCount;

    
    void Update()
    {
        childCount = transform.GetChild(0).childCount;
        if (childCount >= 1)
        {
            isTaken = true;
        }

        switch (childCount == 0)
        {
            case true:
                isTaken = false;
                break;
            case false:
                break;
        }
        
    }
}
