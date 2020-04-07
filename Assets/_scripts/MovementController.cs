using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int remainingTurnCount { get; set; }
    public bool isPlaying { get; set; }

    public float speedMov = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal") * speedMov * Time.deltaTime, Input.GetAxisRaw("Vertical") * speedMov * Time.deltaTime);
        
    }
}
