using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayHandIndication : MonoBehaviour
{
    [SerializeField] GameObject handIndication;
    [SerializeField] Button upgradeButton;
    // Start is called before the first frame update
    void Start()
    {
        CurrencyHolder.instance.OnValueChanged += checkValue;
        upgradeButton.onClick.AddListener(DisableIndication);
    }

    private void DisableIndication()
    {
        Destroy(handIndication);
    }

    private void checkValue(float value)
    {
        if (value == 5)
            handIndication.SetActive(true);
    }

}
