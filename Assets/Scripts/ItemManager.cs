using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> currentItems;

    // all the different bonuses items give
    public int totalHealthBonus;
    public int totalAmmoBonus;
    public float totalSpeedBonus;
    public float totalFireRateBonus;
    public float totalReloadBonus;
    public List<string> currentSpecialAbilities;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // resetting all item bonuses
        totalHealthBonus = 0;
        totalAmmoBonus = 0;
        totalSpeedBonus = 0;
        totalFireRateBonus = 0;
        totalReloadBonus = 0;
        currentSpecialAbilities.Clear();

        for (int i = 0; i < currentItems.Count; i++)
        {
            // re-calculating current bonuses
            totalHealthBonus += currentItems[i].healthBonus;
            totalAmmoBonus += currentItems[i].ammoBonus;
            totalSpeedBonus += currentItems[i].speedBonus;
            totalFireRateBonus += currentItems[i].fireRateBonus;
            totalReloadBonus += currentItems[i].reloadBonus;
            if (currentItems[i].specialAbility != null)
            {
                currentSpecialAbilities.Add(currentItems[i].specialAbility);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewItem(Item newItem)
    {
        currentItems.Add(newItem);
        totalHealthBonus += newItem.healthBonus;
        totalAmmoBonus += newItem.ammoBonus;
        totalSpeedBonus += newItem.speedBonus;
        totalFireRateBonus += newItem.fireRateBonus;
        totalReloadBonus += newItem.reloadBonus;
        if (newItem.specialAbility != null)
        {
            currentSpecialAbilities.Add(newItem.specialAbility);
        }
        if (newItem.healthBonus > 0)
        {
            this.gameObject.GetComponent<PlayerController>().health += newItem.healthBonus;
        }
        this.gameObject.GetComponent<PlayerController>().RecalculateStats();
    }
}
