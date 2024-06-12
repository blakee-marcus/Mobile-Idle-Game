using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCustomerSpawning : MonoBehaviour
{
  void Start()
  {
    StartCoroutine(SpawnCustomer());
  }

  IEnumerator SpawnCustomer()
  {
    while (true)
    {
      Instantiate(GameAssets.i.customerPrefab, GameAssets.i.customerSpawnPoint.position, GameAssets.i.customerSpawnPoint.rotation);
      yield return new WaitForSeconds(GameAssets.i.playerStats.timeBetweenCustomerSpawn); // Wait for 5 seconds before spawning the next customer
    }
  }
}
