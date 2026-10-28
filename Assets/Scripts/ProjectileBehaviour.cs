using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 trueMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (trueMousePos - (Vector2) transform.position).normalized;
        transform.up = direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * projectileSpeed);

        if (transform.position.x > 12 || transform.position.x < -12)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 12 || transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
