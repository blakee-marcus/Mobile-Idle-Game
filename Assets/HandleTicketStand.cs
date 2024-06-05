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
    Vector3 ticketStandPosition = GameAssets.i.ticketStand.transform.position;
    ticketStandPosition.y += 3;
    ProgressBarPopUp.Create(ticketStandPosition, GameAssets.i.playerStats.ticketStandTimeToServe);

    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.ticketStandTimeToServe, AICustomerStateManager.CustomerState.purchaseFood);
  }
}
