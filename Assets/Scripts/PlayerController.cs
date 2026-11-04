using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 7.0f;
    public int health;
    public int maxHealth;
    public int ammo;
    public int maxAmmo;
    public float fireDelay;
    public float reloadDelay;

    [Header("Components and Objects")]
    public GameObject bullet;
    private Animator playerAnimator;
    private ItemManager itemManager;

    // clocks
    private float invincibilityClock = 0f;
    public float invincibilityTime = 1f;
    private float fireClock;
    private float reloadClock;
    

    [Header("Baselines")]
    public float baseSpeed = 7.0f;
    public int baseMaxHealth = 6;
    public int baseMaxAmmo = 12;
    public float baseFireDelay = 0.05f;
    public float baseReloadDelay = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        itemManager = this.GetComponent<ItemManager>();

        maxHealth = baseMaxHealth + itemManager.totalHealthBonus;
        maxAmmo = baseMaxAmmo + itemManager.totalAmmoBonus;
        speed = baseSpeed + itemManager.totalSpeedBonus;
        fireDelay = baseFireDelay / ( 1 + itemManager.totalFireRateBonus);
        reloadDelay = baseReloadDelay / ( 1 +itemManager.totalReloadBonus);

        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Input.GetKey("w"))
        {
            if (transform.position.y < 4)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x > -7.89)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
        }
        if (Input.GetKey("s"))
        {
            if (transform.position.y > -4)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
                playerAnimator.SetInteger("direction", 0);
            }
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x < 7.89)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }

        if (Input.GetKey("w") == false && Input.GetKey("a") == false && Input.GetKey("s") == false && Input.GetKey("d") == false)
        {
            playerAnimator.SetBool("isMoving", false);
        }
        else
        {
            playerAnimator.SetBool("isMoving", true);
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

        // death
        if (health <= 0)
        {
            SceneManager.LoadScene("TitleScreen");
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
        if (GetComponent<SpriteRenderer>().color == Color.red)
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
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    public void RecalculateStats()
    {
        maxHealth = baseMaxHealth + itemManager.totalHealthBonus;
        maxAmmo = baseMaxAmmo + itemManager.totalAmmoBonus;
        speed = baseSpeed + itemManager.totalSpeedBonus;
        fireDelay = baseFireDelay / ( 1 + itemManager.totalFireRateBonus);
        reloadDelay = baseReloadDelay / ( 1 +itemManager.totalReloadBonus);

        // health += itemManager.totalHealthBonus;
    }

}
