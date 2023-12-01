using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerDies : MonoBehaviour
{
    private float endTimer = 2;
    private float resetTimer = 2;

    private void Update()
    {
        if(PlayerMovement.isDead == true)
        {
            StartCoroutine(EndTimer());
        }

        if(PlayerMovement.isGameComplete == true)
        {
            StartCoroutine(EndGame());
        }
    }
    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(endTimer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(resetTimer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
