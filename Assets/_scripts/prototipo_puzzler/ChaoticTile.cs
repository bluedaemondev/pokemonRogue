using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaoticTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManagerPuzzle.current.onDeath += this.KillPlayer;

            GameManagerPuzzle.current.TriggerDeath();
        }
    }

    public void KillPlayer()
    {
        Debug.Log("PERDISTE! reiniciando!!!!!...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
