using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinRotationCalculator))]
public class TapAccelerator : MonoBehaviour
{
    [SerializeField] float maxAcceleration;
    [SerializeField] float tapValue;
    [SerializeField] float delayBeforeDecreasing;
    [SerializeField] float decreasingPace;
    public float MaxAcceleration => maxAcceleration;

    CoinRotationCalculator calculator;
    public float Acceleration { get; private set; } = 0;
    float timeToDecreaseAcceleration;
    int forceId;


    // Start is called before the first frame update
    void Start()
    {
        calculator = GetComponent<CoinRotationCalculator>();
        forceId = calculator.AddForce(0); // register this force and get a force id

        timeToDecreaseAcceleration = Time.time + delayBeforeDecreasing;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToDecreaseAcceleration)
            DecreaseAccelecration();

        calculator.AdjustForce(forceId, Acceleration);
    }

    public void Tapped()
    {
        Acceleration += tapValue;
        Acceleration = Mathf.Min(maxAcceleration, Acceleration);
        timeToDecreaseAcceleration = Time.time + delayBeforeDecreasing;
    }

    void DecreaseAccelecration()
    {
        Acceleration -= decreasingPace * Time.deltaTime;
        Acceleration = Mathf.Max(Acceleration, 0);
    }
}
