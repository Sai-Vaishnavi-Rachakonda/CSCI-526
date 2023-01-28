using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject[] ramdomObjects;
    public int health;

    private void Start()
    {
        StartCoroutine(GenerateFruit());
    }

    IEnumerator GenerateFruit()
    {
        while (health < 3)
        {
            int randomNumber = Random.Range(0, ramdomObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-11, 11), 5, Random.Range(-10, 10));
            Instantiate(ramdomObjects[randomNumber], randomSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(7);
            health += 1;
        }
    }

}
