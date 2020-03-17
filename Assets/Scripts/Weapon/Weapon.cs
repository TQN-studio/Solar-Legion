using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private Transform player;

    private Bullet bullet;

    [SerializeField]
    private Gun[] gun;

    private SpriteRenderer spriteGun;

    private int index;

    void Start()
    {
        index = 0;

        spriteGun = GetComponent<SpriteRenderer>();
        spriteGun.sprite = gun[index].SpriteGun;
        bullet = gun[index].MyBullet;
    }
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(joystick.Vertical, 0.5f) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle * player.localScale.x);
    }

    public void Shoot()
    {
        float angle = Mathf.Atan2(joystick.Vertical, 0.5f) * Mathf.Rad2Deg;
        float direction = player.localScale.x > 0 ? 0 : 1;
        Instantiate(bullet.gameObject, transform.position, Quaternion.Euler(0, 0, angle * player.localScale.x + 180 * direction));
    }
}
