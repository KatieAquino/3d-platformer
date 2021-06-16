using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float bobSpeed;
    public float rotateSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, bobHeight, 0);
    }

    void Update()
    {
        // Position for coint to bob towards or away.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bobSpeed * Time.deltaTime);

        // Rotates coin.
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        // Changes bob direction so it will bob between different positions.
        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
                targetPos = startPos + new Vector3(0, bobHeight, 0);
            else if(targetPos == startPos + new Vector3(0, bobHeight, 0))
                targetPos = startPos;
        }
    }
}
