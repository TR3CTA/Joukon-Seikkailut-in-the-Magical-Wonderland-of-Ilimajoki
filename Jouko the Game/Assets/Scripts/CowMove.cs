using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMove : MonoBehaviour
{
    private float speed = 9f;
    private float startDelay = 4f;

    private float boundaryRange = 65;
    
    // Start is called before the first frame update
    void Start()
    {
        // Make cows change direction on intervals
        int turningRate = Random.Range(3, 10);

        InvokeRepeating("RotateCow", startDelay, turningRate);
    }

    // Update is called once per frame
    void Update()
    {
        // Make cows move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Destroy cow if out of bounds
        // Western boundary
        if (transform.position.x < -boundaryRange)
        {
            Destroy(gameObject);
        }
        // Eastern boundary
        if (transform.position.x > boundaryRange)
        {
            Destroy(gameObject);
        }
        // Southern boundary
        if (transform.position.z < -boundaryRange)
        {
            Destroy(gameObject);
        }
            // Northern boundary
        if (transform.position.z > boundaryRange)
        {
            Destroy(gameObject);
        }        
    }

    void RotateCow()
    {
        // Randomly turn cow left or right 90 degrees
        int leftOrRight;

        if (Random.value < 0.5f)
        {
            leftOrRight = -90;
        }
        else
        {
            leftOrRight = 90;
        }

        transform.Rotate(Vector3.up, leftOrRight);
    }
}
