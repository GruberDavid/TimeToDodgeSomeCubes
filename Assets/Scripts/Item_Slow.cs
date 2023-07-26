using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Slow : Item
{

    public string name = "Item_Slow";

    public Item_Slow(int rarity, int nb_use, bool activated)
    {
        this.rarity = rarity;
        this.nb_used = nb_use;
        this.activated = activated;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Retourne 1 si l'objet peut-être utilisé, 0 sinon
    override
    public int use_effect()
    {
        if (this.rarity == 1 && this.nb_used < 1)
        {
            this.nb_used++;
            return 1;
        }
        else if (this.rarity == 2 && this.nb_used < 1)
        {
            this.nb_used++;
            return 1;
        }
        else if (this.rarity == 3 && this.nb_used < 1)
        {
            this.nb_used++;
            return 1;
        }
        return 0;
    }

    override
    public string getName()
    {
        return this.name;
    }

    override
    public int getUsed()
    {
        return this.nb_used;
    }

}