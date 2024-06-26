using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTicketStand : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    HandleTicketPurchase(customer);
  }

  private void HandleTicketPurchase(AICustomerStateManager customer)
  {
    Vector3 ticketStandPosition = GameAssets.i.ticketStand.transform.position;
    ticketStandPosition.y += 3;
    Debug.Log("Handling ticket purchase for customer");
    ProgressBarPopUp.Create(ticketStandPosition, GameAssets.i.playerStats.ticketStandTimeToServe);
    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.ticketStandTimeToServe, AICustomerStateManager.CustomerState.purchaseFood);

    StartCoroutine(WaitAndAddMoney(GameAssets.i.playerStats.ticketStandTimeToServe));
  }

  private IEnumerator WaitAndAddMoney(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);
    GameAssets.i.playerStats.AddMoney(GameAssets.i.playerStats.ticketPrice);
  }
}
