using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{

    public GameObject Pillar;

    private float printTime;
    private float pillarSpawnYLocation;
    

    private Vector3 pillarSpawnLocation;

    void Start()
    {
        
    }

    
    void Update()
    {
        printTime += Time.deltaTime;

        if (printTime >= 4)
        {
            CreatePillar();
            printTime = 0;
        }
    }

    void CreatePillar()
    {
        pillarSpawnYLocation = Random.Range(-5, 6);

        pillarSpawnLocation = new Vector3(transform.position.x, pillarSpawnYLocation, transform.position.z);

        Instantiate(Pillar, pillarSpawnLocation, transform.rotation);

    }
}
