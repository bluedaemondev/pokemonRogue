using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public static InventoryComponent current;

    public List<CollectableComponent> items = new List<CollectableComponent>();

    // Start is called before the first frame update
    void Awake()
    {
        current = this;  
    }

    public bool SearchOnList(CollectableComponent ccSearch)
    {
        foreach (var item in this.items)
            if(item == ccSearch)
                return true;
        
        return false;
    }

    public void AddToInventory( CollectableComponent ccItem )
    {
        this.items.Add(ccItem);
    }

    //las puertas deberian tener un objeto guardado que simule el template de lo que le hace falta para abrirse
    public void ConsumeItem(CollectableComponent ccItem )
    {
        if (this.items.Contains(ccItem))
        {
            print("you consumed " + ccItem.ToString());
            this.items.Remove(ccItem);
        }
    }


}
