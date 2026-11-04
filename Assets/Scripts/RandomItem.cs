using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public List<GameObject> itemIndex; // list of every item in the game
    private int itemNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemNumber = Random.Range(0, itemIndex.Count);
        GameObject clone = Instantiate(itemIndex[itemNumber], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
