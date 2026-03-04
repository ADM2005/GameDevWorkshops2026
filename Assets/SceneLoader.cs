using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }
    public void LoadScene(string sceneName)
    {
        if (sceneName == "1")
        {
            Destroy(gameManager.gameObject);
        }
        SceneManager.LoadScene(sceneName);
        
    }
}
