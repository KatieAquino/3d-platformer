using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // To keep track of player object.
    public Transform target;
    //To keep camera a certain distance away from player object.
    public Vector3 offset;

    void Update()
    {
        if(target == null)
            return;
        
        // Prevents camera from following user along y axis.
        Vector3 newPos = target.position + offset;
        newPos.y = offset.y;
        
        transform.position = newPos;
    }
}
