using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private Hero[] player;

    [SerializeField]
    private Stat HP;

    [SerializeField]
    private Bag bag;

    [SerializeField]
    private GameObject Heal;

    private int index;

    public float HP_max;

    public float attack;

    public float defense;

    public float speed;

    public float jump;

    public float critical;

    public float cooldown;

    [SerializeField]
    private SSButton skillButton;

    private Rigidbody2D myBody;

    private Animator anim;

    private bool isJumping;

    private bool isUsingSkill;

    public static Player instance;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        GetHero();
        if (instance == null)
        {
            instance = this;
        }
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
        ChangeScale();
        PlayerUseSkill();
        IsUsingSkill();
    }


    void GetHero()
    {
        //if (GameManager.instance != null)
        //{
        //    index = GameManager.instance.GetIndexHero();
        //}

        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = player[index].MyAnim;

        HP.SetInitValue(player[index].MyHP);
        HP_max = player[index].MyHP;
        attack = player[index].MyAttack;
        defense = player[index].MyDefense;
        speed = player[index].MySpeed;
        jump = player[index].MyJump;
        critical = player[index].MyCritical;
        cooldown = player[index].MyCooldown;

        skillButton.Cooldown_max = cooldown;
        skillButton.Icon.sprite = player[index].MyIconSkill;
    }

    void ChangeScale()
    {
        if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void BuffHP(float value)
    {
        Instantiate(Heal, transform.position, Quaternion.identity);
        HP.CurrentValue += value;
    }

    public void TakeDamage(float value)
    {
        float temp = value - defense;
        if (temp > 0)
        {
        HP.CurrentValue -= temp;
        }
    }

    public void SetProperty(ref float property, float value)
    {
        property += value;
        if (property < 0)
        {
            property = 0;
        }
    }

    void IsUsingSkill()
    {
        if (skillButton.Finish)
        {
            isUsingSkill = false;
        }
    }

    void PlayerMove()
    {
        Vector2 temp = myBody.velocity;
        if (joystick.Horizontal > 0.2)
        {
            temp.x = speed;
            WalkAnimation();
        }
        else if (joystick.Horizontal < -0.2)
        {
            temp.x = -speed;
            WalkAnimation();
        }
        else
        {
            temp.x = 0;
            anim.SetBool("Walk", false);
        }
        myBody.velocity = temp;
    }

    void WalkAnimation()
    {
        if (!isJumping)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void PlayerJump()
    {
        if (joystick.Vertical > 0.5)
        {
            if (!isJumping)
            {
                Vector2 temp = myBody.velocity;
                temp.y = jump;
                myBody.velocity = temp;
                isJumping = true;
            }
        }
        
    }

    public void PlayerUseSkill()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isUsingSkill)
            {
                isUsingSkill = true;
                GetComponent<Skill>().SkillImplement(index);
                skillButton.Cooldown();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Land")
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Item")
        {
            bool checkAddItem = bag.AddItem(target.GetComponent<Item>());
            if (checkAddItem)
            {
                Destroy(target.gameObject);
            }
        }
    }
}
