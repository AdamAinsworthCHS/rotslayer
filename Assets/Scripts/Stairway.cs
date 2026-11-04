using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairway : MonoBehaviour
{
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
        if (roomManager.combat == false)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("FloorTransition");
            }
        }
    }
}
