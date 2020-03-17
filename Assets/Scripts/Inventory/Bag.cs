using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private Slot[] slots;

    public bool AddItem(Item item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.empty)
            {
                slot.AddItem(item);
                return true;
            }
        }
        return false;
    }
}
