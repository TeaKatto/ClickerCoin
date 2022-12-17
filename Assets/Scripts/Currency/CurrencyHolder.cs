using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyHolder : MonoBehaviour
{
    public static CurrencyHolder instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    [SerializeField] float currentValue;
    public float CurrentValue => currentValue;

    public event Action<float> OnValueChanged;

    public void AddAmount(float amount)
    {
        currentValue += amount;
        OnValueChanged?.Invoke(currentValue);
    }

    /// <summary>
    /// Trys to reduce the current value by the given amount
    /// </summary>
    /// <param name="amount"> Amount to reduce from the current value</param>
    /// <returns> Returns true if reduction was successfull</returns>
    public bool ReduceAmount(float amount)
    {
        if (amount > currentValue)
            return false;

        AudioManager.instance.Play("purchase");
        currentValue -= amount;
        OnValueChanged?.Invoke(currentValue);
        return true;
    }
}
