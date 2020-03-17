using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillResources : MonoBehaviour
{
    public static SkillResources instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //Skill for assassin
    public GameObject assassinSkill;

    //Skill for tanker
    public GameObject tankerSkill;
}
