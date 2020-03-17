using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerSkillEffect : MonoBehaviour
{
    private Rigidbody2D myBody;
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = Vector2.zero;
    }
}
