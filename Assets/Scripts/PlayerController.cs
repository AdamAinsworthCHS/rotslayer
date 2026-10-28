using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.0f;
    public int health;
    public int maxHealth;
    public int ammo;
    public int maxAmmo;
    public GameObject bullet;

    // clocks
    private float invincibilityClock = 0f;
    public float invincibilityTime = 1f;
    private float fireClock;
    public float fireDelay;
    private float reloadClock;
    public float reloadDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (transform.position.y < 4)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x > -9.5)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
        }
        if (Input.GetKey("s"))
        {
            if (transform.position.y > -4)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x < 9.5)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }

        // shooting mechanic
        if (Input.GetMouseButtonDown(0))
        {
            reloadClock = Time.time + reloadDelay;
            if (fireClock < Time.time)
            {
                fireClock = Time.time + fireDelay;
                if (ammo > 0)
                {
                    GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
                    ammo -= 1;
                }
            }
            
        }

        // passive reloading
        if (reloadClock < Time.time)
        {
            if (ammo < maxAmmo)
            {
                ammo += 1;
                reloadClock = Time.time + reloadDelay;
            }
        }

        // invincibility flash color checker
        if (GetComponent<SpriteRenderer>().color == Color.lightCyan)
        {
            if (invincibilityClock < Time.time)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
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
                GetComponent<SpriteRenderer>().color = Color.lightCyan;
            }
        }
    }

}
