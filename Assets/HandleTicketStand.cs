using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTicketStand : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    if (customer != null && customer.CurrentCustomerState == AICustomerStateManager.CustomerState.purchaseTicket)
    {
      HandleTicketPurchase(customer);
    }
  }

  private void HandleTicketPurchase(AICustomerStateManager customer)
  {
    ProgressBarPopUp.Create(customer.transform.position, 15);
    Debug.Log("Customer has reached the ticket stand and is purchasing a ticket.");

    // Change customer state after purchasing the ticket
    customer.SetCustomerState(AICustomerStateManager.CustomerState.purchaseFood);
  }
}
