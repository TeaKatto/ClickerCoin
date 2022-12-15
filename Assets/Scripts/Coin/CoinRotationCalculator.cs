using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotationCalculator : MonoBehaviour
{
    [SerializeField] float baseVelocity;
    public float rotationSpeed { get; private set; }
    Dictionary<int, float> addedForces = new();

    private void Update()
    {
        CalculateRotationVelocity();
    }
    void CalculateRotationVelocity()
    {
        float sumedForces = AddedForcesSum();
        rotationSpeed = (baseVelocity + sumedForces) * Time.deltaTime;
    }

    float AddedForcesSum()
    {
        float sum = 0;
        foreach(var force in addedForces)
        {
            sum += force.Value;
        }
        return sum;
    }

    public bool AdjustForce(int forceId, float newForce)
    {
        if (!addedForces.ContainsKey(forceId)) return false;

        addedForces[forceId] = newForce;
        return true;
    }

    /// <summary>
    /// Adds a force to be applied every frame
    /// </summary>
    /// <param name="force"></param>
    /// <returns> Returns the force ID for latter adjustments</returns>
    public int AddForce(float force)
    {
        int index = addedForces.Count;
        addedForces.Add(index,force);
        return index;
    }
}
