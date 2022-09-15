using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{

    public Player_Inventory inventory;
    public int rarity;
    public int nb_used;
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    abstract public string getName();

    abstract public int use_effect();


    public int getRarity()
    {
        return this.rarity;
    }

    public bool getActivated()
    {
        return this.activated;
    }

    abstract public int getUsed();


}