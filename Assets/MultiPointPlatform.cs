using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPointPlatform : MonoBehaviour
{
    Vector3 startPos;

    [SerializeField] List<Vector3> points = new List<Vector3>();
    [SerializeField] float moveSpeed = 2f;

    int currentPoint = 0;

    bool stopped;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (stopped || points.Count == 0) return;

        Vector3 target = startPos + points[currentPoint];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentPoint++;
            if (currentPoint >= points.Count)
            {
                currentPoint = 0; // loop back to start
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") &&
            collision.transform.position.y < transform.position.y)
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
