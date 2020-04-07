using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StepCounterUIController : MonoBehaviour
{
    TextMeshProUGUI txtStepCounter;

    public void ChangeTextValue(string newText)
    {
        this.GetComponent<TextMeshPro>().text = newText;
    }
    private void Start()
    {
        this.txtStepCounter = this.GetComponent<TextMeshProUGUI>();
    }
    void LateUpdate()
    {
        this.txtStepCounter.text = GameManagerPuzzle.current.GetGlobalSteps().ToString();
    }
}
