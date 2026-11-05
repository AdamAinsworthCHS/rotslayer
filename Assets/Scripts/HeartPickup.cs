using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private PlayerController player;
    private RoomManager roomManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerController>();
            if ((player.maxHealth - player.health) > 0)
            {
                if ((player.maxHealth - player.health) == 1)
                {
                    player.health += 1;
                }
                else
                {
                    player.health += 2;
                }
                roomManager.rooms[roomManager.position].objects.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
