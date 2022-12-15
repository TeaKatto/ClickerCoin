using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteRotationDetector : MonoBehaviour
{
    float previousAngle, currentAngle;

    public event Action OnRotationComplete;

    // Update is called once per frame
    void Update()
    {
        currentAngle = transform.rotation.eulerAngles.y;
        if (previousAngle > currentAngle) // when the angle drops from 360 to 0
            OnRotationComplete?.Invoke();

        previousAngle = currentAngle;
    }
}
