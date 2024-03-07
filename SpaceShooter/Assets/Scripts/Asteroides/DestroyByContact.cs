using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject PlayerExplosion;

    public GameObject Explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LimitesJuego")
        {
            return;
        }

        Instantiate(Explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation); ;
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
