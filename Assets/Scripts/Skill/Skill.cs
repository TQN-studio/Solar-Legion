using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private Joystick joystickMove;

    private Rigidbody2D myBody;

    private GameObject skill;

    void Start()
    { 
        myBody = GetComponent<Rigidbody2D>();
    }


    public void SkillImplement(int index)
    {
        switch (index)
        {
            case 0:
                {
                    StartCoroutine(AssassinSkill());
                    break;
                }
            case 1:
                {
                    StartCoroutine(TankerSkill());
                    break;
                }
            default: break;
        }
    }

    IEnumerator AssassinSkill()
    {
        //Create
        if (SkillResources.instance != null)
        {
            skill = SkillResources.instance.assassinSkill;
        }
        skill.transform.localScale = transform.localScale;

        //Move
        Vector2 direction = myBody.velocity;
        direction.x = joystickMove.Horizontal;
        direction.y = joystickMove.Vertical;
        direction = direction.normalized;

        for (int i = 0; i < 10; i++)
        {
            Instantiate(skill, transform.position, Quaternion.identity);
            transform.Translate(direction);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator TankerSkill()
    {
        //Create
        if (SkillResources.instance != null)
        {
            skill = SkillResources.instance.tankerSkill;
        }
        GameObject currentSkill = Instantiate(skill, transform.position, Quaternion.identity, transform);
        Player.instance.SetProperty(ref Player.instance.defense, 50);
        //Destroy
        yield return new WaitForSeconds(7);
        Destroy(currentSkill);
        Player.instance.SetProperty(ref Player.instance.defense, -50);
    }
}
