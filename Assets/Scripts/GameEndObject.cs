using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < collision.GetComponent<ItemManager>().currentItems.Count; i++)
            {
                Destroy(collision.GetComponent<ItemManager>().currentItems[i].gameObject);
            }
            Destroy(collision.gameObject);
            SceneManager.LoadScene("TitleScreen");
        }
    }
}