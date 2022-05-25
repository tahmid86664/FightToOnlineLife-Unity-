using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TimeDestructor : MonoBehaviour
{
    public float timeToDestroy = 0f;
    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
