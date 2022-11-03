using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player_Inventory : MonoBehaviour
{

    public List<Item> items;


    private int taux_drop_item_life = 20;
    private int taux_drop_item_multiplicator = 50;
    private int taux_drop_item_slow = 30;

    private int taux_drop_lvl1 = 55;
    private int taux_drop_lvl2 = 30;
    private int taux_drop_lvl3 = 15;

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        this.LoadItems();
        if(this.GetActivatedItem() == null) {
            return;
        }
        if(this.GetActivatedItem().getName() == "Item_Multiplicator"){
            score.setMultiplicator(this.GetActivatedItem().getRarity() + 1);
            this.items.Remove(this.GetActivatedItem());
        }
    }

    //Charger les items depuis un fichier
    public void LoadItems()
    {
        items = new List<Item>();
        string stringItems = "";
        string line;
        try
        {

            StreamReader sr = new("./Items.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                stringItems += line;
                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.Message);
        }
        finally
        {
            string[] tempStringItems = stringItems.Split("+");
            for (int i = 0; i < tempStringItems.Length - 1; i++)
            {

                string[] stringItem = tempStringItems[i].Split("-");
                int rarityItem = int.Parse(stringItem[1]);
                int nb_use = int.Parse(stringItem[2]);
                bool activated = bool.Parse(stringItem[3]);

                if (stringItem[0] == "Item_Life")
                {
                    Item_Life item_life = new(rarityItem, nb_use, activated);
                    items.Add(item_life);
                }
                if (stringItem[0] == "Item_Slow")
                {
                    Item_Slow item_slow = new(rarityItem, nb_use, activated);
                    items.Add(item_slow);
                }
                if (stringItem[0] == "Item_Multiplicator")
                {
                    Item_Multiplicator item_multiplicator = new(rarityItem, nb_use, activated);
                    items.Add(item_multiplicator);
                }
            }

            Debug.Log("Chargement des items depuis le fichier effectué");

        }
    }

    //Enregistrer les items dans un fichier
    public void SaveItems()
    {
        try
        {

            StreamWriter sw = File.CreateText("./Items.txt");
            for (int i = 0; i < items.Count; i++)
            {
                sw.WriteLine(items[i].getName() + "-" + items[i].getRarity() + "-" + items[i].getUsed() + "-" + items[i].getActivated() + "+");
            }

            sw.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.Message);
        }
        finally
        {
            Debug.Log("\nFichier modifié");
        }
    }

    //Génération d'un item
    public void Drop_item()
    {
        System.Random rnd = new();
        int num = rnd.Next(0, 100);
        int num2 = rnd.Next(0, 100);


        if (num < taux_drop_item_life)
        {
            if (num2 < taux_drop_lvl1)
            {
                Item_Life item = new(1, 0, false);
                this.items.Add(item);
            }
            else if (num2 < taux_drop_lvl2 + taux_drop_lvl1)
            {
                Item_Life item = new(2, 0, false);
                this.items.Add(item);
            }
            else
            {
                Item_Life item = new(3, 0, false);
                this.items.Add(item);
            }
        }
        else if (num < taux_drop_item_life + taux_drop_item_slow)
        {
            if (num2 < taux_drop_lvl1)
            {
                Item_Slow item = new(1, 0, false);
                this.items.Add(item);
            }
            else if (num2 < taux_drop_lvl2 + taux_drop_lvl1)
            {
                Item_Slow item = new(2, 0, false);
                this.items.Add(item);
            }
            else
            {
                Item_Slow item = new(3, 0, false);
                this.items.Add(item);
            }
        }
        else
        {
            if (num2 < taux_drop_lvl1)
            {
                Item_Multiplicator item = new(1, 0, false);
                this.items.Add(item);
            }
            else if (num2 < taux_drop_lvl2 + taux_drop_lvl1)
            {
                Item_Multiplicator item = new(2, 0, false);
                this.items.Add(item);
            }
            else
            {
                Item_Multiplicator item = new(3, 0, false);
                this.items.Add(item);
            }
        }



        this.SaveItems();
    }

    public Item GetActivatedItem()
    {
        if (items == null)
        {
            return null;
        }
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].getActivated())
            {
                return items[i];
            }
        }
        return null;
    }

    public List<Item_Life> GetItemsLife()
    {
        if (items == null)
        {
            return null;
        }
        List<Item_Life> return_Items = new();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].getName() == "Item_Life")
            {
                Item_Life temp_item_life = new(items[i].getRarity(), items[i].getUsed(), items[i].getActivated());
                return_Items.Add(temp_item_life);
            }
        }
        return return_Items;
    }

    public List<Item_Slow> GetItemsSlow()
    {
        if (items == null)
        {
            return null;
        }
        List<Item_Slow> return_Items = new();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].getName() == "Item_Slow")
            {
                Item_Slow temp_item_slow = new(items[i].getRarity(), items[i].getUsed(), items[i].getActivated());
                return_Items.Add(temp_item_slow);
            }
        }
        return return_Items;
    }

    public List<Item_Multiplicator> GetItemsMultiplicator()
    {
        if (items == null)
        {
            return null;
        }
        List<Item_Multiplicator> return_Items = new();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].getName() == "Item_Multiplicator")
            {
                Item_Multiplicator temp_item_multiplicator = new(items[i].getRarity(), items[i].getUsed(), items[i].getActivated());
                return_Items.Add(temp_item_multiplicator);
            }
        }
        return return_Items;
    }

    public void ActivateItem(int index)
    {
        for(int i=0; i < items.Count; i++)
        {
            items[i].activated = (i == index);

        }
        
    }
}