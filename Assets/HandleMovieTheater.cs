using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovieTheater : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    if (customer != null && customer.CurrentCustomerState == AICustomerStateManager.CustomerState.watchMovie)
    {
      HandleMovieViewing(customer);
    }
  }

  private void HandleMovieViewing(AICustomerStateManager customer)
  {
    Vector3 movieTheaterPosition = GameAssets.i.movieTheater.transform.position;
    movieTheaterPosition.y += 3;
    ProgressBarPopUp.Create(movieTheaterPosition, GameAssets.i.playerStats.movieTheaterTimeToServe);

    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.movieTheaterTimeToServe, AICustomerStateManager.CustomerState.leaveTheater);
  }
}
