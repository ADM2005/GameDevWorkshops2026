using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] public bool Paused => paused;
    bool paused;
    [SerializeField] GameObject pauseMenu;
    void Start()
    {
        paused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Unpause();
            else Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        
        pauseMenu.SetActive(true);
    }

    void Unpause()
    {
        Time.timeScale = 1;
        paused = false;
        
        pauseMenu.SetActive(false);
    }
}
