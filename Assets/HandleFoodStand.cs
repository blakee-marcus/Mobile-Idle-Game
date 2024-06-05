using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFoodStand : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    if (customer != null && customer.CurrentCustomerState == AICustomerStateManager.CustomerState.purchaseFood)
    {
      HandleFoodPurchase(customer);
    }
  }

  private void HandleFoodPurchase(AICustomerStateManager customer)
  {
    Vector3 foodStandPosition = GameAssets.i.foodStand.transform.position;
    foodStandPosition.y += 3;
    ProgressBarPopUp.Create(foodStandPosition, GameAssets.i.playerStats.foodStandTimeToServe);
    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.foodStandTimeToServe, AICustomerStateManager.CustomerState.watchMovie);
  }
}
