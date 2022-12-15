using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpinner : MonoBehaviour
{
    [SerializeField] float spinningForce;
    CoinRotationCalculator calculator;

    int forceId;
    bool isRegisteredInCalculator = false;
    // Start is called before the first frame update
    void Start()
    {
        calculator = FindObjectOfType<CoinRotationCalculator>();
        AddForceToRotationCalculator();
    }
    

    void AddForceToRotationCalculator()
    {
        forceId = calculator.AddForce(spinningForce);
        isRegisteredInCalculator = true;
    }

    public void AdjustForce(float newForce)
    {
        if (!isRegisteredInCalculator) return;
        spinningForce = newForce;
        calculator.AdjustForce(forceId, spinningForce);
    }
}
