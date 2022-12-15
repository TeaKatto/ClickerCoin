using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanUpgrader : AbstractUpgrader
{
    AutoSpinner fan;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fan = GetComponentInChildren<AutoSpinner>();
    }

    protected override void Upgrade(Upgrade upgrade)
    {
        fan.AdjustForce(upgrade.value);
    }

}
