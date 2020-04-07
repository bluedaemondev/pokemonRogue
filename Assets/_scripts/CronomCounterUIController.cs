using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CronomCounterUIController : MonoBehaviour
{
    TextMeshProUGUI txtCron;
    // Start is called before the first frame update
    void Start()
    {
        this.txtCron = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.txtCron.text = String.Format("{0:0.00}", GameManagerPuzzle.current.maxLevelTime - Time.timeSinceLevelLoad) + 's';
        //valido contra 0 para tener niveles sin limite de tiempo
        if (Time.timeSinceLevelLoad >= GameManagerPuzzle.current.maxLevelTime && GameManagerPuzzle.current.maxLevelTime != 0)
        {
            print("Perdiste por cronometro. Reiniciando / Finalizando escena");
            GameManagerPuzzle.current.TriggerDeath();
        }
        else
            GameObject.FindGameObjectWithTag("Cronometro").GetComponent<TextMeshProUGUI>().text = "";
    }

}
