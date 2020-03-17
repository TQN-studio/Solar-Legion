using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string name;

    [SerializeField]
    private Sprite icon;

    public Sprite MyIcon { get => icon;}
    public string MyName { get => name;}
}
