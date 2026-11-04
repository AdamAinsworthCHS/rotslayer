using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public List<Item> pickedItems;
    public List<int> pickedButtonIDs;
    private ItemManager itemManager;
    public Canvas canvas;
    public GameObject buttonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemManager = GameObject.Find("Player").GetComponent<ItemManager>();
        // GET OUTTA HERE PLAYER!!!
        GameObject.Find("Player").transform.position = new Vector2 (999, 999);

        // create the buttons
        int row = 0;
        int col = 0;

        Debug.Log(itemManager.currentItems.Count);

        for (int i = 0; i < itemManager.currentItems.Count; i++)
        {
            Debug.Log("made button " + i);
            // clone the prefab
            GameObject clone = Instantiate(buttonPrefab, transform.position, transform.rotation);
            // set the parent
            clone.transform.SetParent(canvas.transform, false);
            // set the id
            clone.GetComponent<ItemButton>().buttonID = i;
            // set the item stored
            clone.GetComponent<ItemButton>().itemStored = itemManager.currentItems[i];
            // set the position
            clone.transform.position = new Vector2(row * 175 + 100f, col * -175 + 750);

            row++;
            if (row > 10)
            {
                col++;
                row = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
