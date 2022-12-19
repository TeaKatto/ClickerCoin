using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveTapIndicator : MonoBehaviour
{
    [SerializeField] Button tapButton;
    // Start is called before the first frame update
    void Start()
    {
        tapButton.onClick.AddListener(RemoveTapAnimation);
    }

    private void RemoveTapAnimation()
    {
        tapButton.onClick.RemoveListener(RemoveTapAnimation);
        Destroy(gameObject);
    }

}
