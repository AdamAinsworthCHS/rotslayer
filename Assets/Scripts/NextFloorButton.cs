using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextFloorButton : MonoBehaviour
{
    private Button button;
    private ItemPicker itemPicker;
    private ItemManager itemManager;
    public List<Item> tempItemList; // list to keep track of items to be decayed.
    private Item decayingItem; // current item being decayed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        itemPicker = GameObject.Find("ItemPicker").GetComponent<ItemPicker>();
        itemManager = GameObject.Find("Player").GetComponent<ItemManager>();
        tempItemList = itemManager.currentItems;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void TaskOnClick()
    {
        // removing protected items fromt he queue
        for (int i = 0; i < itemPicker.pickedItems.Count; i++)
        {
            tempItemList.Remove(itemPicker.pickedItems[i]);
        }

        // decaying all unprotected items
        for (int i = 0; i < tempItemList.Count; i++)
        {
            decayingItem = itemManager.currentItems[itemManager.currentItems.IndexOf(tempItemList[i])];
            if (decayingItem.decayed == true)
            {
                itemManager.currentItems.Remove(decayingItem);
                Destroy(decayingItem.gameObject);
            }
            else
            {
                decayingItem.decayed = true;
                if (decayingItem.healthBonus > 1)
                {
                    decayingItem.healthBonus /= 2;
                }
                if (decayingItem.ammoBonus > 1)
                {
                    decayingItem.ammoBonus /= 2;
                }
                if (decayingItem.speedBonus > 0)
                {
                    decayingItem.speedBonus /= 2;
                }
                if (decayingItem.fireRateBonus > 0)
                {
                    decayingItem.fireRateBonus /= 2;
                }
                if (decayingItem.reloadBonus > 0)
                {
                    decayingItem.reloadBonus /= 2;
                }
                if (decayingItem.specialAbility != null)
                {
                    decayingItem.specialAbility = "decayed_" + decayingItem.specialAbility;
                }
            }
        }

        GameObject.Find("Player").GetComponent<PlayerController>().floor += 1;
        SceneManager.LoadScene("PlayerTest");
    }
}