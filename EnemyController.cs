using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Vector3 offsetEndPos;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + offsetEndPos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
                targetPos = startPos + offsetEndPos;
            else if(targetPos == startPos + offsetEndPos)
                targetPos = startPos;
        }
    }
}
