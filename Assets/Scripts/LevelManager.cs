using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int gemsRemaining;
    List<Collectable> collectables;
    GameManager gameManager;

    [SerializeField] private String nextLevelName;
    public void GemCollected()
    {
        gemsRemaining--;
    }
    
    void Start()
    {
        collectables = FindObjectsOfType<Collectable>().ToList();
        gemsRemaining = collectables.Count;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gemsRemaining <= 0)
        {
            // Go to next level
            if (nextLevelName == "Winscreen")
            {
                if (PlayerPrefs.HasKey("best_time"))
                {
                    float previousBest =  PlayerPrefs.GetFloat("best_time");
                    PlayerPrefs.SetFloat("best_time", Mathf.Min(previousBest, gameManager.GetTimeElapsed()));
                }
                else
                {
                    PlayerPrefs.SetFloat("best_time", gameManager.GetTimeElapsed());
                }
            }
            SceneManager.LoadScene(nextLevelName);

            
        }
    }
}
