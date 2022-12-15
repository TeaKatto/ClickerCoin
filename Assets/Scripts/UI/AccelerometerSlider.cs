using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AccelerometerSlider : MonoBehaviour
{
    TapAccelerator accelerator;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        accelerator = FindObjectOfType<TapAccelerator>();

        slider.maxValue = accelerator.MaxAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = accelerator.Acceleration;
    }
}
