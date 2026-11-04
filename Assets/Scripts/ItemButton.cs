using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private Button button;
    public int buttonID;
    public Item itemStored;
    private ItemPicker itemPicker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        itemPicker = GameObject.Find("ItemPicker").GetComponent<ItemPicker>();
        this.GetComponent<Image>().sprite = itemStored.itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemPicker.pickedButtonIDs.Contains(buttonID))
        {
            this.GetComponent<Image>().color = Color.green;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }

    void TaskOnClick()
    {
        if (itemPicker.pickedButtonIDs.Contains(buttonID))
        {
            itemPicker.pickedItems.Remove(itemStored);
            itemPicker.pickedButtonIDs.Remove(buttonID);
            Debug.Log("added to lsit!");
        }
        else
        {
            if (itemPicker.pickedButtonIDs.Count < 2)
            {
                itemPicker.pickedItems.Add(itemStored);
                itemPicker.pickedButtonIDs.Add(buttonID);
                Debug.Log("removed from lsit!");
            }
        }
        
    }
}
