using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        
        if (score == 100)
        {
            GameObject Background = GameObject.Find("stars_5");
            Destroy(Background);          
        }
        if (score == 200)
        {
            GameObject Background = GameObject.Find("stars_3");
            Destroy(Background);
        }
        if (score == 300)
        {
            GameObject Background = GameObject.Find("stars_2");
            Destroy(Background);
        }
        if (score == 400)
        {
            GameObject Background = GameObject.Find("stars_1");
            Destroy(Background);
        }

    }

    public void ResetScore()
    {
        score = 0;
    }
}
