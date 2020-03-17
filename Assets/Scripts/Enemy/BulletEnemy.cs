
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
	[SerializeField]
	private float speed = 50f;

	[SerializeField]
	private float damage;

	[SerializeField]
	private GameObject boom;

	private Rigidbody2D bullet;
	private GameObject player;

	void Start()
	{
		bullet = GetComponent<Rigidbody2D>();
		Move();
		StartCoroutine(DestroyBullet());
	}

	void Move()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Vector2 direction = player.transform.position - transform.position;
		direction.Normalize();
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
		bullet.velocity = direction * speed;
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
			target.gameObject.GetComponent<Player>().TakeDamage(damage);
		}

		if (target.gameObject.tag == "Shield")
		{
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (target.gameObject.tag == "Land")
		{
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(1);
		Instantiate(boom, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
