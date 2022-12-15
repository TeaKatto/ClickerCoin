using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinRotationCalculator))]
public class CoinSpinner : MonoBehaviour
{
    CoinRotationCalculator calculator;

    Vector3 Rotation = new();

    // Start is called before the first frame update
    void Start()
    {
        calculator = GetComponent<CoinRotationCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        spin(calculator.rotationSpeed);
    }

    void spin(float amount)
    {
        Rotation.y = amount;
        transform.Rotate(Rotation);
    }
}
