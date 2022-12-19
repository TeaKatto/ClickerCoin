using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotationAnimator : MonoBehaviour
{
    [SerializeField] Transform fanBlades;
    [SerializeField] int speedIncrements = 100;
    [SerializeField] Vector3 rotation = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        fanBlades.Rotate(rotation * Time.deltaTime);
    }

    public void increaseFanRotationSpeed()
    {
        rotation.x += speedIncrements;
    }
}
