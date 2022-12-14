using System;
using UnityEngine;

public class CompleteRotationDetector : MonoBehaviour
{
    [SerializeField] float rotationValue;
    float previousAngle, currentAngle;
    public float RotationValue
    {
        get { return rotationValue; }
        set
        {
            if (value >= 1)
                rotationValue = value;
        }
    }

    public event Action<float> OnRotationComplete;

    private void Awake()
    {
        rotationValue = 1;
    }
    // Update is called once per frame
    void Update()
    {
        currentAngle = transform.rotation.eulerAngles.y;
        if (previousAngle > currentAngle) // when the angle drops from 360 to 0
        {
            OnRotationComplete?.Invoke(rotationValue);
            AudioManager.instance.Play("coin");
        }

        previousAngle = currentAngle;
    }
}
