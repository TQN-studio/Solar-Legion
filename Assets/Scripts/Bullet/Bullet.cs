using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeToDestroy;

    [SerializeField]
    private GameObject boom;

    private Rigidbody2D myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Moverment();
        StartCoroutine(DestroyBullet());
    }

    void Moverment()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction = Vector2.zero;
        direction.x = angle > Mathf.PI / 2 && angle < Mathf.PI * 3 / 2 ? -0.5f : 0.5f;
        direction.y = direction.x * Mathf.Tan(angle);
        direction = direction.normalized;
        myBody.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Land")
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (target.gameObject.tag == "Enemy")
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
            target.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}