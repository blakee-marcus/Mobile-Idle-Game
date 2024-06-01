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
    Debug.Log("Customer has reached the ticket stand and is purchasing a ticket.");

    // Change customer state after purchasing the ticket
    customer.SetCustomerState(AICustomerStateManager.CustomerState.leaveTheater);
  }
}
