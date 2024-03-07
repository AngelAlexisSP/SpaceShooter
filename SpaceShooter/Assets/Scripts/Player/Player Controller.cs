using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public GameObject shot;
    public Transform shotSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); 
        }

    }
    private void FixedUpdate()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

///////////////////////////////////////////////////////////////////////////////////////////////////

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = movimiento * velocidad;

        GetComponent<Rigidbody>().position = new Vector3
           (
           Mathf.Clamp(GetComponent<Rigidbody>().position.x, GetComponent<Limites>().xMin, GetComponent<Limites>().xMax),
           Mathf.Clamp(GetComponent<Rigidbody>().position.y, GetComponent<Limites>().yMin, GetComponent<Limites>().yMax),
           0.0f
           );

///////////////////////////////////////////////////////////////////////////////////////////////////
        
    }
}
