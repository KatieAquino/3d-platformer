using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    // Instance for easier access.
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
}
