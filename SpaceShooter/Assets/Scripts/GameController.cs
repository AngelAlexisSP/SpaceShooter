using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject OrdasAsteroides;

    public Vector3 spawnValues;

    public int NumEnemies;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    IEnumerator Spawnwaves ()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < NumEnemies; i++)
            {

                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(OrdasAsteroides, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds (waveWait);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Spawnwaves ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
