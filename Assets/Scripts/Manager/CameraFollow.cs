using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y + 2.5f;
        transform.position = temp;
    }
}
