using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPuzzle : MonoBehaviour
{
    public static GameManagerPuzzle current;

    //set singleton to this instance
    private void Awake()
    {
        current = this;

        current.onDeath += this.ResetStepCount;
        current.onWinScene += this.LoadNextScene;
        //current.onDeath += this.DieMessage;

    }


    //para el manejo de el paso de nivel 
    public event Action onWinScene;
    public event Action onDeath;


    //para manejo de eventos de interruptor
    public event Action<int> onSwitchTrigger;

    //hay que cambiar esto. Step active = true indica si esta activado el parpadeo de trampas/plataformas cada x pasos (1 con bool)
    //public bool stepActive = false;

    [SerializeField]
    //contador global de pasos dados por el jugador
    private int totalStepCount = 0;

    //para el cronometro
    public float maxLevelTime = 0;
    private GameObject cronometro;


    //para pasos con switch de estado de varias plataformas/entidades
    public event Action onSwitchGlobalStep;


    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ResetStepCount()
    {
        this.totalStepCount = 0;
    }

    /// <summary>
    /// incrementa el global de pasos en el nivel
    /// </summary>
    /// <returns>Devuelve el nuevo total de pasos</returns>
    public int IncreaseGlobalSteps()
    {
        this.totalStepCount += 1;
        //print("Total step count : " + totalStepCount + " Activando eventos");
        this.MakeGlobalStep();

        return this.totalStepCount;
    }

    /// <summary>
    /// Getter comun
    /// </summary>
    /// <returns></returns>
    public int GetGlobalSteps()
    {
        return this.totalStepCount;
    }


    #region Invocadores

    /// <summary>
    /// Invocadores de eventos
    /// </summary>
    /// <param name="idx"> indice de entidades asociadas que van a hacer switch </param>
    public void SwitchTriggerEnter(int idx)
    {
        if (onSwitchTrigger != null)
        {
            onSwitchTrigger(idx);
            ResetStepCount();
            this.totalStepCount++;
            //IncreaseGlobalSteps();
        }
    }

    /// <summary>
    /// Invocador de paso global. llama a todos los eventos que esten suscritos a onSwitchGlobalStep
    /// </summary>
    /// <param name="idx"> indice de entidades asociadas que van a hacer switch </param>
    public void MakeGlobalStep()
    {
        if (onSwitchGlobalStep != null)
        {
            onSwitchGlobalStep();
        }

    }
    //Win scene
    public void TriggerWin()
    {
        if (onWinScene != null)
        {
            onWinScene();
        }
    }

    public void TriggerDeath()
    {
        if (onDeath != null)
        {
            onDeath();
        }
    }
    #endregion


    private void Update()
    {
        
    }

}
