using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHRotate : MonoBehaviour
{
    public GameObject LHLightSource;
    public float speed = 0.1f;

    void Update()
    {
        LHLightSource.transform.Rotate(0.0f, speed, 0.0f, Space.World);
    }
}
