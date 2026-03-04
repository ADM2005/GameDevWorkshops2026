using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    TimerDisplay timerDisplay;
    float timeElapsed;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        timeElapsed = 0;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerDisplay = FindObjectOfType<TimerDisplay>();
    }
    

    void Start()
    {
        timerDisplay = FindObjectOfType<TimerDisplay>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if(timerDisplay) timerDisplay.DisplayTime(timeElapsed);
    }

    public float GetTimeElapsed()
    {
        return timeElapsed;
    }
}
