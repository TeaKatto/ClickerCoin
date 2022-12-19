using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenuButton : MonoBehaviour
{
    [SerializeField] GameObject debugMenuObject;

    bool isSetActive = true;

    public void ToggleActive()
    {
        debugMenuObject.SetActive(isSetActive);
        isSetActive = !isSetActive;
    }
}
