using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableComponent : MonoBehaviour
{
    public enum Type
    {
        Key = 0,
        Item = 1, // colectables o monedas?
        Ability = 2, // Habilidad o mecanica 
    }

    public string nameCollectable;
    public Type myTipe;

    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        this.collider = this.GetComponent<Collider2D>();

        if (!this.collider.isTrigger)
            this.collider.isTrigger = true;
    }

    public override string ToString()
    {
        return String.Concat(base.ToString() , " Name: " , nameCollectable , " Tipo: " , myTipe.ToString());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player recolecto :" + this.nameCollectable + " de tipo: " + this.myTipe.ToString());
            InventoryComponent.current.AddToInventory(this);

            Destroy(this.gameObject);
        }

    }
}
