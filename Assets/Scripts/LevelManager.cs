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

    [SerializeField] private String nextLevelName;

    public void GemCollected()
    {
        gemsRemaining--;
    }
    
    void Start()
    {
        collectables = FindObjectsOfType<Collectable>().ToList();
        gemsRemaining = collectables.Count;
    }

    void Update()
    {
        if (gemsRemaining <= 0)
        {
            // Go to next level
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
