using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public GameObject objectToSpawn;
    public Transform[] spawnPoints;
    public float destroyTarget;

    bool spawn;

    public float spawnInterval;

    private void Awake()
    {
        spawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            SpawnObject();
        } 
    }

    void SpawnObject()
    {
        spawn = false;
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;
        Quaternion spawnRotation = spawnPoints[randomIndex].rotation;

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        Destroy(spawnedObject,destroyTarget);

        Invoke("RespawnTarget", spawnInterval);
    }

    void RespawnTarget()
    {
        spawn = true;
    }
}
