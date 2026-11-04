using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairway : MonoBehaviour
{
    private RoomManager roomManager;
    public Sprite closedSprite;
    public Sprite openSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomManager.combat == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = openSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (roomManager.combat == false)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("FloorTransition");
            }
        }
    }
}
