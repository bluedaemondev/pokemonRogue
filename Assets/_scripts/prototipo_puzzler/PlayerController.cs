using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public  float maxTileMovement = 1f;
    public  int maxTurnMovements = 6;
    private Animator animatorPlayer;



    //// Start is called before the first frame update
    void Start()
    {
        this.animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            float xSign = Input.GetAxisRaw("Horizontal");
            float ySign = Input.GetAxisRaw("Vertical");

            Vector2 movTarget = new Vector2(maxTileMovement * xSign, maxTileMovement * ySign);
            //Debug.DrawRay(transform.position, movTarget, Color.black);

            //si no tengo algo enfrente,
            if(!RaycastIsHittingTile(transform.position, movTarget, maxTileMovement))
            {
                transform.position += (Vector3)movTarget;  //new Vector3(maxTileMovement * xSign, maxTileMovement * ySign, 0);.
                this.animatorPlayer.Play("babaisrun");
                //this.animatorPlayer.SetBool("isWalking", true);
                GameManagerPuzzle.current.IncreaseGlobalSteps();
                //this.animatorPlayer.SetBool("isWalking", false);

                //muevo!
            }
        }

    }
    bool RaycastIsHittingTile(Vector3 origin, Vector3 dest, float maxDist)
    {
        bool status = false;
        
        //no puede atravesar enemigos? chaotic deberia estar dividido en 2 capas (enemy, tile), considerando si hay enemigos
        if (//Physics2D.Raycast(origin, dest, maxDist, LayerMask.GetMask("chaotic")) ||
            Physics2D.Raycast(origin, dest, maxDist, LayerMask.GetMask("Default")))
        {
            status = true;
        }
        
        return status;
    }
}
