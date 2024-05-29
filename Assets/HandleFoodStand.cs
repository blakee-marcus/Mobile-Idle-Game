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
        Debug.Log("Customer has reached the food stand and is purchasing food.");

        customer.SetCustomerState(AICustomerStateManager.CustomerState.watchMovie);
    }
}
