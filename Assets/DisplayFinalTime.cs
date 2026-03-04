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
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time) - minutes * 60;
        int ms = Mathf.FloorToInt( (time - seconds) * 1000);
        
        tmp.text = $"Time: {minutes:00}:{seconds:00}:{ms:00}";
    }
    
    
}
