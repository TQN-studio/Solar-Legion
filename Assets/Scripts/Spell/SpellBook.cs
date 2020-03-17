using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellBook
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Sprite iconSpell;
    [SerializeField]
    private float cooldown;

    public string MyName { get => name; set => name = value; }
    public Sprite IconSpell { get => iconSpell;}
    public float Cooldown { get => cooldown;}
}
