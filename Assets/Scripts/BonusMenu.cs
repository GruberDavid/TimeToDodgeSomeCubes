using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusMenu : MonoBehaviour
{
    public Player_Inventory inventory;

    public TMP_Dropdown dropdown;

    private List<Item> itemList;

    public void UpdateUI()
    {
        itemList = new List<Item>();
        List<Item_Life> ilList = inventory.getItemsLife();
        foreach(Item_Life item in ilList)
        {
            itemList.Add(item);
        }
        List<Item_Slow> isList = inventory.getItemsSlow();
        foreach (Item_Slow item in isList)
        {
            itemList.Add(item);
        }
        List<Item_Multiplicator> imList = inventory.getItemsMultiplicator();
        foreach (Item_Multiplicator item in imList)
        {
            itemList.Add(item);
        }

        List<string> optionList = new List<string>();
        foreach (Item item in itemList)
        {
            optionList.Add(item.getName());
        }

        dropdown.AddOptions(optionList);
    }

    public void ActivateItem()
    {
        Debug.Log("Activate selected item");
        int index = dropdown.value;
    }

    public void LeaveBonusMenu()
    {
        gameObject.SetActive(false);
    }
}
