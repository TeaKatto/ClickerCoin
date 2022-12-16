using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUpgrader : AbstractUpgrader
{
    CompleteRotationDetector rotationDetector;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationDetector = FindObjectOfType<CompleteRotationDetector>();
    }

    protected override void Upgrade(Upgrade upgrade)
    {
        rotationDetector.RotationValue = upgrade.value; // increase value multimlier for each rotation
        ReplaceToNewGameObject(upgrade.visualUpgrade);   
    }

}
