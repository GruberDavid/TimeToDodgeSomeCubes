using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player_Inventory : MonoBehaviour
{

	public List<Item> items;

/*
	private float taux_drop_item_life = 0.2;
	private float taux_drop_item_multiplicator = 0.5;
	private float taux_drop_item_slow = 0.3;
*/

    // Start is called before the first frame update
    void Start()
    {
    	this.loadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Charger les items depuis un fichier
    public void loadItems(){
    	items = new List<Item>();
    	string stringItems = "";
    	string line;
    	try
        {
            
            StreamReader sr = new StreamReader("./Items.txt");
           	line = sr.ReadLine();
            while (line != null)
            {
                stringItems = stringItems + line;
                line = sr.ReadLine();
            }
               
            sr.Close();
        }
        catch(Exception e)
        {
            Debug.Log("Exception: " + e.Message);
        }
        finally
        {
        	string[] tempStringItems = stringItems.Split("+");

        	for(int i = 0; i < tempStringItems.Length -1; i++) {

        		string[] stringItem = tempStringItems[i].Split("-");
        		int rarityItem = int.Parse(stringItem[1]);
        		int nb_use = int.Parse(stringItem[2]);

        		if(stringItem[0] == "Item_Life") {
        			Item_Life item_life = new Item_Life(rarityItem, nb_use);
        			items.Add(item_life);
        		}
        		if(stringItem[0] == "Item_Slow") {
        			Item_Slow item_slow = new Item_Slow(rarityItem, nb_use);
        			items.Add(item_slow);
        		}
        		if(stringItem[0] == "Item_Multiplicator") {
        			Item_Multiplicator item_multiplicator = new Item_Multiplicator(rarityItem, nb_use);
        			items.Add(item_multiplicator);
        		}
        	}
        	
            Debug.Log("Chargement des items depuis le fichier effectué");

        }
    }

    //Enregistrer les items dans un fichier
    public void saveItems(){
    	try
		{

		    StreamWriter sw = new StreamWriter("./Items.txt");
		    for(int i =0; i < items.Count; i++){
			    sw.WriteLine(items[i].getName() + "-" + items[i].getRarity() + "-" + items[i].getUsed() + "+");
    		}
		    
		    sw.Close();
		}
		catch(Exception e)
		{
		    Debug.Log("Exception: " + e.Message);
		}
		finally
		{
		    Debug.Log("\nFichier modifié");
		}
    }
       
    //Génération d'un item
    public void drop_item(){  
    	Debug.Log("\nDROP Items Player_Inventory");
    	Item_Life test_item_life = new Item_Life(2, 0);
    	this.items.Add(test_item_life);
    	this.saveItems();
    }

    public Item getActivatedItem(){
    	if(items == null) {
    		return null;
    	}
    	for(int i =0; i < items.Count; i++){
    		if(items[i].getActivated()){
    			return items[i];
    		}
    	}
    	return null;
    }

    public List<Item_Life> getItemsLife() {
    	if(items == null) {
    		return null;
    	}
    	List<Item_Life> return_Items = new List<Item_Life>();
    	for(int i =0; i < items.Count; i++){
    		if(items[i].getName() == "Item_Life"){
    			Item_Life temp_item_life = new Item_Life(items[i].getRarity(), items[i].getUsed());
    			return_Items.Add(temp_item_life);
    		}
    	}
    	return return_Items;
    }

    public List<Item_Slow> getItemsSlow() {
    	if(items == null) {
    		return null;
    	}
    	List<Item_Slow> return_Items = new List<Item_Slow>();
    	for(int i =0; i < items.Count; i++){
    		if(items[i].getName() == "Item_Slow"){
    			Item_Slow temp_item_slow = new Item_Slow(items[i].getRarity(), items[i].getUsed());
    			return_Items.Add(temp_item_slow);
    		}
    	}
    	return return_Items;
    }

    public List<Item_Multiplicator> getItemsMultiplicator() {
    	if(items == null) {
    		return null;
    	}
    	List<Item_Multiplicator> return_Items = new List<Item_Multiplicator>();
    	for(int i =0; i < items.Count; i++){
    		if(items[i].getName() == "Item_Multiplicator"){
    			Item_Multiplicator temp_item_multiplicator = new Item_Multiplicator(items[i].getRarity(), items[i].getUsed());
    			return_Items.Add(temp_item_multiplicator);
    		}
    	}
    	return return_Items;
    }


}
