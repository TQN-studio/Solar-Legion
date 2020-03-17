using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

public class NormalEnemy : Enemy
{

	public float speed = 4f;
	private Rigidbody2D myBody;
	private Animator anim;
	private bool check;

	[SerializeField]
	private GameObject gun;

	[SerializeField]
	private BulletEnemy bullet;
	private float BulletTimer;

	void Start()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		HP.SetInitValue(100);
	}

	void ChangeDirection()
	{
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;
	}

	void FixedUpdate()
	{
		Move();
		Attack();
	}

	void Move()
	{
		anim.SetBool("Walk", true);
		myBody.velocity = new Vector2(-transform.localScale.x, 0) * speed;
		if (check == true)
		{
			myBody.velocity = new Vector2(transform.localScale.x, 0) * 0f;
		}
	}

	void GunRotate(GameObject target)
	{
		Vector3 direction = target.transform.position - gun.transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		float temp = direction.x < 0 ? 1 : 2;
		gun.transform.rotation = Quaternion.Euler(0, 0, angle + 180 * temp);
	}

	private void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Wall" )
		{
			ChangeDirection();
		}
	}

	void OnTriggerStay2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			check = true;
			GunRotate(target.gameObject);
			anim.SetBool("Walk", false);
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
			check = false;
	}

	void Attack()
	{
		BulletTimer += Time.deltaTime;
		StopCoroutine(CallBullet());
		if (check == true && BulletTimer >= 1)
		{
			StartCoroutine(CallBullet());
			BulletTimer = 0;
		}
	}

	IEnumerator CallBullet()
	{
		Instantiate(bullet, gun.transform.position, Quaternion.identity);
		yield return null;
	}
}
