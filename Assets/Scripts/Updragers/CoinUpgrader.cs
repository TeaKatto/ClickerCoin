using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUpgrader : MonoBehaviour
{
    [SerializeField] GameObject activeCoin;
    [SerializeField] Transform coinHolder;
    [SerializeField] CoinUpdrage[] upgrades;

    public int UpgradeCost => upgrades[index].cost;

    int index = 0;

    CurrencyHolder currencyHolder;
    CompleteRotationDetector rotationDetector;
    
    // Start is called before the first frame update
    void Start()
    {
        currencyHolder = FindObjectOfType<CurrencyHolder>();
        rotationDetector = FindObjectOfType<CompleteRotationDetector>();
    }

    public void TryUpgradeCoin()
    {
        if(currencyHolder.CurrentValue > upgrades[index].cost)
        {
            Upgrade();
            //return true;
        }
        //return false;
    }

    private void Upgrade()
    {
        rotationDetector.RotationValue = upgrades[index].multiplier; // increase value multimlier for each rotation
        ReplaceByNewCoin(upgrades[index].coinType);   
        currencyHolder.ReduceAmount(upgrades[index].cost);  // pay for the upgrade
        index++;
    }

    private void ReplaceByNewCoin(GameObject coin)
    {
        Destroy(activeCoin);
        activeCoin = Instantiate(coin, coinHolder);

    }
}
