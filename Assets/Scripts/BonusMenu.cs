using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusMenu : MonoBehaviour
{
    public GameObject menu;

    public Player_Inventory inventory;

    public TMP_Dropdown dropdown;

    private List<Item> itemList;

    public void UpdateUI()
    {
        inventory.LoadItems();
        itemList = inventory.items;

        List<string> optionList = new()
        {
            "No item"
        };
        foreach (Item item in itemList)
        {
            optionList.Add(item.getName() + " lvl " + item.getRarity());
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(optionList);
    }

    public void ActivateItem()
    {
        Debug.Log("Activate selected item");
        int index = dropdown.value-1;

        if (index >= 0)
        {
            inventory.ActivateItem(index);
        }
    }

    public void SaveBonus()
    {
        inventory.SaveItems();
        LeaveBonusMenu();
    }

    public void LeaveBonusMenu()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
