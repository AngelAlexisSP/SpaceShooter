using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * moveSpeed;
    }
}
