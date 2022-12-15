using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CurrencyValueDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    CurrencyHolder currencyHolder;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        currencyHolder = FindObjectOfType<CurrencyHolder>();
        currencyHolder.OnValueChanged += DisplayValue;
    }

    private void DisplayValue(float value)
    {
        if (value >= 10000000)
            text.text = (value / 1000000).ToString("c1") + "M";

        else if (value >= 10000)
            text.text = (value / 1000).ToString("c1") + "K";

        else
        text.text = value.ToString("C0");
    }

}
