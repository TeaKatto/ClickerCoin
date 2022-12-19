using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DisplayCost : MonoBehaviour
{
    [SerializeField] AbstractUpgrader upgrader;

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        upgrader.OnUpgraded += UpdatePrice;
        UpdatePrice();
    }

    private void UpdatePrice()
    {
        if (upgrader.isMaxLevel)
            text.text = "Max level";

        else
            text.text = "$" + upgrader.UpgradeCost.ToString();
    }

}
