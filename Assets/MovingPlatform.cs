using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;
    [SerializeField] Vector3 targetOffset;
    [SerializeField] float timePeriod;

    bool stopped;
    float t;
    void Start()
    {
        t = 0;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            transform.position = startPos + targetOffset * Mathf.PingPong(t / timePeriod,1);
            t += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && collision.transform.position.y < this.transform.position.y)
        {
            stopped = true;
        }
        collision.transform.SetParent(transform);
    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.transform.CompareTag("Player") && stopped)
        {
            stopped = false;
        }
        collision.transform.SetParent(null);
        
    }
}
