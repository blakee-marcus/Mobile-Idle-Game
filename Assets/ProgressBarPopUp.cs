using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPopUp : MonoBehaviour
{
    private Camera mainCamera;
    private Slider slider;
    private float disappearTimer;
    private float maxTime;

    // Static method to create a ProgressBarPopUp at a specific position
    public static ProgressBarPopUp Create(Vector3 position, int maxTime)
    {
        if (GameAssets.i == null)
        {
            Debug.LogError("GameAssets instance is null");
            return null;
        }

        if (GameAssets.i.progressBarPopUp == null)
        {
            Debug.LogError("ProgressBarPopUp prefab is not assigned in GameAssets");
            return null;
        }

        // Instantiate the progress bar prefab from GameAssets
        Transform progressBarPopUpTransform = Instantiate(GameAssets.i.progressBarPopUp, position, Quaternion.identity);

        if (progressBarPopUpTransform == null)
        {
            Debug.LogError("Failed to instantiate ProgressBarPopUp prefab");
            return null;
        }

        // Get the ProgressBarPopUp component and set it up
        ProgressBarPopUp progressBarPopUp = progressBarPopUpTransform.GetComponent<ProgressBarPopUp>();

        if (progressBarPopUp == null)
        {
            Debug.LogError("ProgressBarPopUp component not found on the instantiated prefab");
            return null;
        }

        progressBarPopUp.Setup(maxTime);
        return progressBarPopUp;
    }

    private void Awake()
    {
        // Get the Slider component attached to the transform
        slider = transform.GetComponent<Slider>();

        if (slider == null)
        {
            Debug.LogError("Slider component not found on ProgressBarPopUp");
        }
    }

    private void Start()
    {
        // Get the main camera in the scene
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found");
        }
    }

    // Setup the progress bar with the maximum time
    public void Setup(float maxTime)
    {
        Debug.Log("Setting up progress bar with max time: " + maxTime);
        Debug.Log("Slider value: " + slider.value);
        
        this.maxTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = 0f;
        disappearTimer = 0f;
    }

    private void Update()
    {
        // Rotate the progress bar to face the camera
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);

        // Update the disappear timer and slider value
        disappearTimer += Time.deltaTime;
        slider.value = disappearTimer;

        // Destroy the game object when the timer exceeds maxTime
        if (disappearTimer >= maxTime)
        {
            Destroy(gameObject);
        }
    }
}
