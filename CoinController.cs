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
}
