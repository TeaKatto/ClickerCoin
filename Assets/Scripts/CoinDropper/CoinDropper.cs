using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public float dropValue;

    CompleteRotationDetector rotationDetector;
    // Start is called before the first frame update
    void Start()
    {
        rotationDetector = FindObjectOfType<CompleteRotationDetector>();

        rotationDetector.OnRotationComplete += GainMoney;
    }

    private void GainMoney(float multiplier)
    {
        CurrencyHolder.instance.AddAmount(dropValue * multiplier);
    }

}
