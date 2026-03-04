using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI tmp;
    public void DisplayTime(float time)
    {
        tmp.text = GetTimeString(time);
    }

    public static string GetTimeString(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60f); 
        int ms = Mathf.FloorToInt( (time - Mathf.Floor(time)) * 1000);
        
        string outString = $"{minutes:00}:{seconds:00}:{ms:00}";
        return outString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
