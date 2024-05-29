using System.Collections;
using UnityEngine;

public class HandleExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
      Debug.Log("Customer has reached the exit.");
        // Attempt to get the AICustomerStateManager component from the collider
        AICustomerStateManager customer = collider.GetComponent<AICustomerStateManager>();
        
        // If the customer is in the state to leave the theater, handle the exit
        if (customer != null && customer.CurrentCustomerState == AICustomerStateManager.CustomerState.leaveTheater)
        {
            HandleExitTheater(customer);
        }
    }

    private void HandleExitTheater(AICustomerStateManager customer)
    {
        Debug.Log("Customer has reached the exit and is leaving the theater.");

        // Start the coroutine to fade out the customer and then destroy the game object
        StartCoroutine(FadeOutAndDestroy(customer.gameObject));
    }

    private IEnumerator FadeOutAndDestroy(GameObject customer)
    {
        Debug.Log("Fading out customer and destroying game object.");
        // Assume the customer has a Renderer component to fade out. Adjust if using a different component.
        Renderer renderer = customer.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogWarning("No Renderer found on the customer object to fade out.");
            Destroy(customer);
            yield break;
        }

        // Assuming the customer has a material with a shader that supports transparency
        Material material = renderer.material;
        Color originalColor = material.color;
        float fadeDuration = 1.0f; // Duration in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Ensure the color is set to fully transparent at the end
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Destroy the customer object after fading out
        Destroy(customer);
    }
}
