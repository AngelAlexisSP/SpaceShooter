using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public GameObject shot;
    public Transform shotSpawn;

    public float FireRate;
    public float nextFire;

    public GameObject ChShot;
    public float ChSpeed;
    public float ChTime;
    private bool Charging;


    private void Update()
    {

        if (Input.GetKey(KeyCode.X) && ChTime < 2)
        {
            Charging = true;
            if (Charging == true)
            {
                ChTime += Time.deltaTime * ChSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.X) && ChTime < 2)
        {
            ChTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.X) && Time.time >= nextFire)
        {
            nextFire = Time.time + FireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        else if (Input.GetKeyUp(KeyCode.X) && ChTime >= 2)
        {
            ReleaseCharge();
        }

    }


    void ReleaseCharge()
    {
        Instantiate(ChShot, shotSpawn.position, shotSpawn.rotation);
        Charging = false;
        ChTime = 0;
    }


    //////////////////////////////////////////////

    private void FixedUpdate()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");


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
