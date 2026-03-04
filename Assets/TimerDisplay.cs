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
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time) - minutes * 60;
        int ms = Mathf.FloorToInt( (time - seconds) * 1000);
        
        tmp.text = $"{minutes:00}:{seconds:00}:{ms:00}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
