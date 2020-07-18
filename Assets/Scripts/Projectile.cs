using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;

    Rigidbody2D rigidbody2d;

    Vector2 startPos;

    Vector2 dir;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(startPos, currentPos) > 20)
        {
            Destroy(gameObject);
        }
        else
        {
            rigidbody2d.MovePosition(currentPos + dir * speed * Time.deltaTime);
        }
    }

    public void Launch(Vector2 direction)
    {
        dir = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
        if (enemyScript)
        {
            enemyScript.ChangeHealth(-1);
            Destroy(gameObject);
        }

    }
}
