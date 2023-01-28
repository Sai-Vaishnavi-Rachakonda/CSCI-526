using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomObjectSpwaner : MonoBehaviour
{
    public GameObject[] ramdomObjects;
    public int fruitCount;

    private void Start()
    {
        StartCoroutine(GenerateFruit());
    }

    IEnumerator GenerateFruit()
    {
        while (fruitCount < 10)
        {
            int randomNumber = Random.Range(0, ramdomObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-11, 11), 5, Random.Range(-15, 10));
            Instantiate(ramdomObjects[randomNumber], randomSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(3);
            fruitCount += 1;
        }
    }
    
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         int randomNumber = Random.Range(0, ramdomObjects.Length);
    //         Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
    //
    //         Instantiate(ramdomObjects[randomNumber], randomSpawnPosition, Quaternion.identity);
    //
    //     }
    // }
}
