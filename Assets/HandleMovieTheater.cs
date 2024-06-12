using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovieTheater : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    HandleMovieEntry(customer);
  }

  private void HandleMovieEntry(AICustomerStateManager customer)
  {
    Vector3 movieTheaterPosition = GameAssets.i.movieTheater.transform.position;
    movieTheaterPosition.y += 3;
    ProgressBarPopUp.Create(movieTheaterPosition, GameAssets.i.playerStats.movieTheaterTimeToServe);
    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.movieTheaterTimeToServe, AICustomerStateManager.CustomerState.leaveTheater);
    
    StartCoroutine(WaitAndServeCustomer(GameAssets.i.playerStats.movieTheaterTimeToServe, customer));
  }

  private IEnumerator WaitAndServeCustomer(float waitTime, AICustomerStateManager customer)
  {
    yield return new WaitForSeconds(waitTime);
    customer.CurrentCustomerState = AICustomerStateManager.CustomerState.leaveTheater;
  }
}
