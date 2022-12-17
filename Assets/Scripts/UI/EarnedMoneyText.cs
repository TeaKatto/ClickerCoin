using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EarnedMoneyText : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    [SerializeField] CoinDropper coinDropper;
    [SerializeField] float animationSpeed;
    [SerializeField] float animationDuration = .8f;

    Vector3 originalPosition;
    Dictionary<float,GameObject> texts = new();
    List<float> removalList = new();
    bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        coinDropper.OnMoneyEarned += OnMoneyEarned;
        originalPosition = transform.position;
    }

    void OnMoneyEarned(float moneyEarned)
    {
        GameObject textHolder = Instantiate(textPrefab, transform);
        texts.Add(Time.time + animationDuration, textHolder);
        TextMeshProUGUI text = textHolder.GetComponent<TextMeshProUGUI>();
        text.text = moneyEarned.ToString("C0");
    }

    private void Update()
    {
        foreach(var textHolder in texts)
        {
            if(textHolder.Key < Time.time)
            {
                removalList.Add(textHolder.Key);
            }
            else
                textHolder.Value.transform.Translate(Vector3.up * animationSpeed * Time.deltaTime);
        }

        RemoveTimedOutTexts();
    }

    private void RemoveTimedOutTexts()
    {
        foreach(var key in removalList)
        {
            GameObject toRemove = texts[key];
            texts.Remove(key);
            Destroy(toRemove);
        }
        removalList.Clear();
    }
}
