using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLayingBackground : MonoBehaviour
{
    public GameObject egg;
    void Start()
    {

        InvokeRepeating("LayEgg", 0f, 1f);
    }

    public void LayEgg()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(0, 0),
            Random.Range(0, 0),
            0.0f
            );
        Quaternion spawnRotation = Quaternion.identity;
        GameObject instance = Instantiate(egg, spawnPosition, spawnRotation);
        instance.transform.parent = GameObject.FindWithTag("UI").transform;

    }

}
