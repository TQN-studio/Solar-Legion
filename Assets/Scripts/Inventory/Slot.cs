using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Item item;

    [SerializeField]
    private Image iconItem;

    public bool empty;

    private void Start()
    {
        empty = true;
    }
    private void Update()
    {
        DisplayItem();
    }

    public void AddItem(Item item)
    {
        this.item = item;
        empty = false;
        Debug.Log(item.MyName);
    }

    void DisplayItem()
    {
        if (!empty)
        {
            iconItem.sprite = item.MyIcon;
            iconItem.color = Color.white;
        }
        else
        {
            iconItem.sprite = null;
            iconItem.color = Color.clear;
        }
    }

    public void UseItem()
    {
        ItemFunction();
        item = null;
        empty = true;
    }

    void ItemFunction()
    {
        if (!empty)
        {
            if (item.MyName == "HealthPotion")
            {
                Player.instance.BuffHP(20);
            }
        }
    }
}
