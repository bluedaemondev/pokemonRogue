using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    public CollectableComponent ccTemplate;

    private void Start()
    {
        if (this.CompareTag("Untagged"))
            this.tag = "Finish";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.CompareTag("Finish"))
        {
            //mi inventario contiene el item que hace falta para abrir la puerta?
            if (InventoryComponent.current.SearchOnList(ccTemplate))
            {
                print("you win");
                GameManagerPuzzle.current.TriggerWin();
            }
        }

    }
}
