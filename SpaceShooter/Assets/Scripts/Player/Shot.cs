using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float shotSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * shotSpeed;
    }
}
