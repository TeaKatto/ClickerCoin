using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AddMoneyButton : MonoBehaviour
{
    [SerializeField] float amountToAdd = 1000;
    Button button;
    CurrencyHolder currencyHolder;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(AddMoney);
        currencyHolder = FindObjectOfType<CurrencyHolder>();
    }

    private void AddMoney()
    {
        currencyHolder.AddAmount(amountToAdd);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(AddMoney);
    }
}
