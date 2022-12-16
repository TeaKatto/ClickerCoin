using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUpgrader : MonoBehaviour
{
    [SerializeField] protected GameObject activeGameObject;
    [SerializeField] protected Transform parentTransform;
    [SerializeField] protected Upgrade[] upgrades;

    public int UpgradeCost => upgrades[index].cost;
    public bool isMaxLevel => index >= upgrades.Length;

    protected int index = 0;

    protected abstract void Upgrade(Upgrade upgrade);

    public virtual void TryUpgrade()
    {
        if (isMaxLevel) return;
        if (CurrencyHolder.instance.CurrentValue > upgrades[index].cost)
        {
            Upgrade(upgrades[index]);
            CurrencyHolder.instance.ReduceAmount(upgrades[index].cost);  // pay for the upgrade
            index++;
        }
    }
    protected void ReplaceToNewGameObject(GameObject upgradedObject)
    {
        Destroy(activeGameObject);
        activeGameObject = Instantiate(upgradedObject, parentTransform);

    }
}
