using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchComponent : MonoBehaviour
{
    public enum State
    {
        Active = 1,
        Inactive = 0
    }

    //ya se activo?
    public bool firstTouch = false;

    public State myState = State.Inactive;
    public Collider2D collider;
    public int[] relatedObjectIds;

    public bool isEnabled = true;

    public void SwitchState()
    {
        this.myState = this.myState == State.Active ? State.Inactive : State.Active;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEnabled)
        {
            isEnabled = false;
            Debug.Log("Collision with player, switching to " + (this.myState == State.Active ? "Inactive" : "Active"));
            this.SwitchState();

            if (this.myState == State.Active)
            {
                foreach (var item in this.relatedObjectIds)
                {
                    //0 es el associate id por defecto, no se suscribe nada por id = 0.
                    GameManagerPuzzle.current.SwitchTriggerEnter(item);
                    //mando un aviso a todos los que tengan suscripcion e indice = item;
                }
            }
        }
    }

}
