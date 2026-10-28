using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 3f;
    public float health;
    private float flashClock = 0f;
    public float flashTime = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (GetComponent<SpriteRenderer>().color == Color.crimson)
        {
            if (flashClock < Time.time)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void FixedUpdate() {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            health -= collision.GetComponent<ProjectileBehaviour>().damage;
            Debug.Log("damage!" + Time.time.ToString());
            GetComponent<SpriteRenderer>().color = Color.crimson;
            flashClock = Time.time + flashTime;
        }
    }
}
