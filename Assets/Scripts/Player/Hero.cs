using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Hero
{
    [SerializeField]
    private string name;
    [SerializeField]
    private float HP;
    [SerializeField]
    private float attack;
    [SerializeField]
    private float defense;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    [SerializeField]
    private float critical;
    [SerializeField]
    private RuntimeAnimatorController anim;
    [SerializeField]
    private Sprite spriteHero;
    [SerializeField]
    private string skillName;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private Sprite iconSkill;

    public string MyName { get => name; set => name = value; }

    public float MyHP { get => HP; set => HP = value; }

    public float MyAttack { get => attack; set => attack = value; }
    
    public float MyDefense { get => defense; set => defense = value; }
    
    public float MySpeed { get => speed; set => speed = value; }
    
    public float MyJump { get => jump; set => jump = value; }
    
    public float MyCritical { get => critical; set => critical = value; }
    public RuntimeAnimatorController MyAnim { get => anim;}
    public Sprite MySpriteHero { get => spriteHero;}
    public string MySkillName { get => skillName;}
    public float MyCooldown { get => cooldown; set => cooldown = value; }
    public Sprite MyIconSkill { get => iconSkill;}
}