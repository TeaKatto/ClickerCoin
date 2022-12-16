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

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(AddMoney);
    }

    private void AddMoney()
    {
        CurrencyHolder.instance.AddAmount(amountToAdd);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(AddMoney);
    }
}
