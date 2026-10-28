using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public string doorID;
    private RoomManager roomManager;
    public Vector2 startPos;
    public Vector2 endPos;
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
            if (roomManager.combat == false)
            {
                if (doorID == "Exit")
                {
                    if (roomManager.position > 0)
                    {
                        roomManager.position -= 1;
                        collision.transform.position = endPos;
                        roomManager.InitiateRoom();
                    }
                }
                else if (doorID == "Entrance")
                {
                    if (roomManager.position < roomManager.rooms.Count - 1)
                    {
                        roomManager.position += 1;
                        collision.transform.position = startPos;
                        roomManager.InitiateRoom();
                    }
                }
            }
        }
    }
}
