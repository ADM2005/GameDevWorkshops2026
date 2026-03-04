using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float hoverAmplitude = 0.5f;
    [SerializeField] float hoverFrequency = 2f;

    LevelManager levelManager;

    float startY;
    void Start()
    {
        levelManager = transform.parent.GetComponent<LevelManager>();
        startY = transform.position.y;
    }

    void Update()
    {
        float newY =  startY + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.GemCollected();
            Destroy(this.gameObject);
        }
    }
}
