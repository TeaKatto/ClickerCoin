using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanUpgrader : AbstractUpgrader
{
    AutoSpinner fan;
    FanRotationAnimator rotationAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fan = GetComponentInChildren<AutoSpinner>();
        rotationAnimator = GetComponentInChildren<FanRotationAnimator>();
    }

    protected override void Upgrade(Upgrade upgrade)
    {
        fan.AdjustForce(upgrade.value);
        rotationAnimator.increaseFanRotationSpeed();
    }

}
