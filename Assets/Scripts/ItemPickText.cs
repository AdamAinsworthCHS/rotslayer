using Unity.VisualScripting;
using UnityEngine;

public class ItemPickText : MonoBehaviour
{
    private ItemPicker itemPicker;
    public int textID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemPicker = GameObject.Find("ItemPicker").GetComponent<ItemPicker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textID == 0)
        {
            if (itemPicker.pickedItems.Count > 0)
            {
                GetComponent<TMPro.TextMeshProUGUI>().text = "Item 1: " + itemPicker.pickedItems[textID].itemName + ": " + itemPicker.pickedItems[textID].itemDescription;
            }
            else
            {
                GetComponent<TMPro.TextMeshProUGUI>().text = "Item 1:";
            }
            
        }
        else
        {
            if (itemPicker.pickedItems.Count > 1)
            {
                GetComponent<TMPro.TextMeshProUGUI>().text = "Item 2: " + itemPicker.pickedItems[textID].itemName + ": " + itemPicker.pickedItems[textID].itemDescription;
            }
            else
            {
                GetComponent<TMPro.TextMeshProUGUI>().text = "Item 2:";
            }
        }
        
    }
}
