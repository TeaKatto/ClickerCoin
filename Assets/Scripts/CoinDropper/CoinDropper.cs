using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public float dropValue;

    CompleteRotationDetector rotationDetector;
    CurrencyHolder currencyHolder;
    // Start is called before the first frame update
    void Start()
    {
        rotationDetector = FindObjectOfType<CompleteRotationDetector>();
        currencyHolder = FindObjectOfType<CurrencyHolder>();

        rotationDetector.OnRotationComplete += GainMoney;
    }

    private void GainMoney(float multiplier)
    {
        currencyHolder.AddAmount(dropValue * multiplier);
    }

}
