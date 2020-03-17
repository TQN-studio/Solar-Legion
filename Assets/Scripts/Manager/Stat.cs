using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float currentValue;

    private Image currentFill;

    public float MaxValue { get => maxValue; set => maxValue = value; }
    public float CurrentValue
    {
        get => currentValue;
        set
        {
            currentValue = value;
        }
    }

    void Start()
    {
        currentFill = GetComponent<Image>();
    }

    void Update()
    {
        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        else if (currentValue < 0)
        {
            currentValue = 0;
        }
        DisplayFill();
    } 

    void DisplayFill()
    {
        currentFill.fillAmount = currentValue / maxValue;
    }

    public void SetInitValue(float value)
    {
        currentValue = value;
        maxValue = value;
    }
}