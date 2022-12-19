using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankUpgrader : AbstractUpgrader
{
    [SerializeField] CoinDropper piggyBank;


    protected override void Upgrade(Upgrade upgrade)
    {
        piggyBank.dropValue = upgrade.value;
    }
}
