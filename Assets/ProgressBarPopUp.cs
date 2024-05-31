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

    public static ProgressBarPopUp Create(Vector3 position, int maxTime)
    {
        Transform progressBarPopUpTransform = Instantiate(GameAssets.i.progressBarPopUp, position, Quaternion.identity);

        ProgressBarPopUp progressBarPopUp = progressBarPopUpTransform.GetComponent<ProgressBarPopUp>();
        progressBarPopUp.Setup(maxTime);
        return progressBarPopUp;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
    }

    public void Setup(int maxTime)
    {
        this.maxTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = 0f;
        disappearTimer = 0f;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
        
        disappearTimer += Time.deltaTime;
        slider.value = disappearTimer;

        if (disappearTimer >= maxTime)
        {
            Destroy(gameObject);
        }
    }
}
