using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Stat HP;

    public void TakeDamage(float value)
    {
        HP.CurrentValue -= value;
        Die();
    }

    void Die()
    {
        if (HP.CurrentValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
