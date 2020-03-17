using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField]
    private SpellBook[] spell;
    [SerializeField]
    private SSButton spellButton;

    private int index;

    private float cooldown;

    private bool isUsingSpell;

    void Start()
    {
        index = 1;
        cooldown = spell[index].Cooldown;
        spellButton.Cooldown_max = cooldown;
        spellButton.Icon.sprite = spell[index].IconSpell;
    }

    // Update is called once per frame
    void Update()
    {
        if (spellButton.Finish)
        {
            isUsingSpell = false;
        }
    }

    public void SpellImplement()
    {
        if (!isUsingSpell)
        {
            isUsingSpell = true;
            spellButton.Cooldown();
            switch (index)
            {
                case 0:
                    {
                        Heal();
                        break;
                    }
                case 1:
                    {
                        StartCoroutine(Ghost());
                        break;
                    }
                default: break;
            }
        }
    }

    void Heal()
    {
        if (Player.instance != null)
        {
            Player.instance.BuffHP(200 + Player.instance.HP_max * 20 / 100);
        }
    }

    IEnumerator Ghost()
    {
        float buffSpeed = Player.instance.speed * 50 / 100;
        float buffJump = Player.instance.jump * 30 / 100;
        if (Player.instance != null)
        {
            Player.instance.SetProperty(ref Player.instance.speed, buffSpeed);
            Player.instance.SetProperty(ref Player.instance.jump, buffJump);
            yield return new WaitForSeconds(5);
            Player.instance.SetProperty(ref Player.instance.speed, -buffSpeed);
            Player.instance.SetProperty(ref Player.instance.jump, -buffJump);
        }
    }
}
