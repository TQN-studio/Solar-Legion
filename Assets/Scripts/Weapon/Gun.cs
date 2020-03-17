using UnityEngine;
[System.Serializable]

public class Gun
{
    [SerializeField]
    private string name;

    [SerializeField]
    private float fireRate; // toc do ban 

    [SerializeField]
    private float range; // tam ban

    [SerializeField]
    private Sprite spriteGun;

    [SerializeField]
    private Bullet bullet;

    public string MyName { get => name; set => name = value; }

    public float MyFireRate { get => fireRate; set => fireRate = value; }

    public float MyRange { get => range; set => range = value; }

    public Sprite SpriteGun { get => spriteGun; }
    public Bullet MyBullet { get => bullet;}
}