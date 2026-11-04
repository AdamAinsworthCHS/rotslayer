using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public List<GameObject> itemIndex; // list of every item in the game
    public List<GameObject> obtainableItems; // items that haven't been gotten yet
    private int itemNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < itemIndex.Count; i++)
        {
            obtainableItems.Add(itemIndex[i]);
        }
        itemNumber = Random.Range(0, obtainableItems.Count);
        GameObject clone = Instantiate(obtainableItems[itemNumber], transform.position, transform.rotation);
        obtainableItems.Remove(obtainableItems[itemNumber]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
