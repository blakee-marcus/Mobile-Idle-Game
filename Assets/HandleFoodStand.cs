using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFoodStand : MonoBehaviour
{

  private void OnTriggerEnter(Collider collider)
  {
    AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
    HandleFoodPurchase(customer);
  }

  private void HandleFoodPurchase(AICustomerStateManager customer)
  {
    Vector3 foodStandPosition = GameAssets.i.foodStand.transform.position;
    foodStandPosition.y += 3;
    ProgressBarPopUp.Create(foodStandPosition, GameAssets.i.playerStats.foodStandTimeToServe);
    CustomerTaskHandler.Instance.StartCustomerTask(customer, GameAssets.i.playerStats.foodStandTimeToServe, AICustomerStateManager.CustomerState.watchMovie);
    StartCoroutine(WaitAndAddMoney(GameAssets.i.playerStats.foodStandTimeToServe));
  }

  private IEnumerator WaitAndAddMoney(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);
    GameAssets.i.playerStats.AddMoney(GameAssets.i.playerStats.foodPrice);
  }
}
