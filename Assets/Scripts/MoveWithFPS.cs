using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFPS : MonoBehaviour
{
    // Start is called before the first frame update
    public int fps;
    public float distPerFrame;

    public Vector3 direction = new Vector3(0f,0f,1f);
    public float distance = 8f;
    float frameTime;
    
    float travelled;
    float timeSinceLastFrame;
    
    
    void Start()
    {
        frameTime = 1 / (float)fps;
        timeSinceLastFrame = 0f;
        travelled = 0f;
    }
    void Update()
    {
        timeSinceLastFrame += Time.deltaTime;
        if (travelled < distance)
        {
            if (timeSinceLastFrame >= frameTime)
            {
                timeSinceLastFrame -= frameTime;
                transform.position += direction * distPerFrame;
                travelled += distPerFrame;
            }
        }
    }
}
