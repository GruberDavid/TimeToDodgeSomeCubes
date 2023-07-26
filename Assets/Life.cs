using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{
	public int lifePoints;
	public Player_Inventory inventory;
	public TMP_Text lifeText;
    // Start is called before the first frame update
    void Start()
    {
        inventory.LoadItems();
        Item item = inventory.GetActivatedItem();
        if (item != null)
        	if(item.getName()=="Item_Life"){
        		SetLife(item.getRarity());
        	}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLife(int i)
    {
    	lifePoints = i;
		lifeText.text = lifePoints.ToString();
    }
}
