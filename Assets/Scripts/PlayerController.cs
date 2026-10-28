using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.0f;
    public int health;
    private float invincibilityClock = 0f;
    public float invincibilityTime = 1f;
    public GameObject bullet;
    private float shootCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (shootCooldown < Time.time)
            {
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
                shootCooldown = Time.time + 0.2f;
            }
            
        }
    }

    // enemy damage detection
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (invincibilityClock < Time.time)
            {
                health -= 1;
                invincibilityClock = Time.time + invincibilityTime;
            }
        }
    }

}
