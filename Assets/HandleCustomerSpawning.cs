using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCustomerSpawning : MonoBehaviour
{
  private float timeSinceLastSpawn = 0.0f;

  void Update()
  {
    timeSinceLastSpawn += Time.deltaTime;
    if (timeSinceLastSpawn >= 5.0f)
    {
      StartCoroutine(SpawnCustomer());
      timeSinceLastSpawn = 0.0f;
    }
  }

  IEnumerator SpawnCustomer()
  {
    // Instantiate a new customer at spawn point
    timeSinceLastSpawn = 0.0f;
    yield return null;
  }
  
}
