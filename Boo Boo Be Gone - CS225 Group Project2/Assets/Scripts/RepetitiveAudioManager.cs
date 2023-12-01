using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetitiveAudioManager : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] levelMusic = GameObject.FindGameObjectsWithTag("Music");

        if (levelMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
