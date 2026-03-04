using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFinalTime : MonoBehaviour
{
    // Start is called before the first frame update

    GameManager gameManager;
    [SerializeField] TextMeshProUGUI tmp;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        float time;

        if (gameManager)
        {
            time =  gameManager.GetTimeElapsed();
        }
        else
        {
            time = 0f;
        }
        float bestTime = PlayerPrefs.GetFloat("best_time");
        tmp.text = $"Time: {TimerDisplay.GetTimeString(time)}\n"
                 + $"Best: {TimerDisplay.GetTimeString(bestTime)}\n";
    }
    
    
}
