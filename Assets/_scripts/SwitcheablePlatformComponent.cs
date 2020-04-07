using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitcheablePlatformComponent : MonoBehaviour
{

    public int associate_id;
    public int stepsToSwitchState = 0;

    public State myState;

    private BoxCollider2D collider;
    private SpriteRenderer sprRend;

    public enum State
    {
        Active = 1,
        Inactive = 0
    }

    private void Start()
    {
        sprRend = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();


        GameManagerPuzzle.current.onSwitchTrigger += SwitchPlatformState;
        GameManagerPuzzle.current.onSwitchGlobalStep += SwitchPlatformState;

    }
    public void SwitchPlatformState()
    {
        //condicion sin id para eventos de pasos globales
        if (this.stepsToSwitchState != 0 &&
            GameManagerPuzzle.current.GetGlobalSteps() % this.stepsToSwitchState == 0
            )
        {
            SwitchState();
        }
    }
    public void SwitchPlatformState(int id)
    {
        //este recibe el id directamente de un switch
        if (id == this.associate_id)
        {
            //me cuelgo del total de pasos que dio el jugador
            this.stepsToSwitchState = GameManagerPuzzle.current.GetGlobalSteps();

            if (GameManagerPuzzle.current.GetGlobalSteps() != 0 &&
                GameManagerPuzzle.current.GetGlobalSteps() % this.stepsToSwitchState == 0 &&
                this.stepsToSwitchState >= GameManagerPuzzle.current.GetGlobalSteps())
                
                SwitchState();
        }
    }

    public void SwitchState()
    {
        this.myState = this.myState == State.Active ? State.Inactive : State.Active;
        if (this.myState == State.Active)
        {
            sprRend.enabled = collider.enabled = true;
            print("Estado activo");
        }
        else
        {
            print("Estado inactivo");

            sprRend.enabled = collider.enabled = false;
        }
    }
}
