using System.Collections;
using UnityEngine;

public class CustomerTaskHandler : MonoBehaviour
{
  public static CustomerTaskHandler Instance { get; private set; }

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void StartCustomerTask(AICustomerStateManager customer, float timeToComplete, AICustomerStateManager.CustomerState nextState)
  {
    Debug.Log("Starting customer task: " + nextState);
    StartCoroutine(CompleteCustomerTask(customer, timeToComplete, nextState));
  }

  private IEnumerator CompleteCustomerTask(AICustomerStateManager customer, float timeToComplete, AICustomerStateManager.CustomerState nextState)
  {
    yield return new WaitForSecondsRealtime(timeToComplete);
    customer.SetCustomerState(nextState);
  }
}
