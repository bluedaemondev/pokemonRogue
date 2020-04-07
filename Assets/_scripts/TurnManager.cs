using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    enum Jugadores
    {
        Player = 0,
        IA = 1,
    }

    public static TurnManager turnManager = new TurnManager();

    public int currentTurn { get; set; }
    public int playerPlaying { get; set; }
    public delegate void TurnHandler();

    // Update is called once per frame
    void Update()
    {

    }
}
