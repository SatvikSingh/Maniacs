using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float destroyTime;

    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
