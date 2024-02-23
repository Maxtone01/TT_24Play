using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _mapVariants;

    private int _choosenMapVariantIndex;

    public GameObject mapPartObject;

    private float mapGroundXScale;

    private Vector3 spawnPosition;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnBoard"))
        {
            SpawnMapPart();
        }
    }

    private void SpawnMapPart()
    {
        _choosenMapVariantIndex = Random.Range(0, _mapVariants.Count);
        
         GameObject mapObject = Instantiate(_mapVariants[_choosenMapVariantIndex], GetPointToSpawnMapPart(mapPartObject), 
            Quaternion.identity);
         mapPartObject = mapObject;
    }

    private Vector3 GetPointToSpawnMapPart(GameObject newCreatedMapPart)
    {
        spawnPosition = new Vector3(newCreatedMapPart.transform.position.x + 10, 0, 0);
        return spawnPosition;
    }
}
