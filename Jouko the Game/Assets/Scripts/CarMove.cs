using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private float speed = 11;
    private float boundaryRange = 65;

    private GameObject turnPointObject;
    private Vector3 turnPoint;
    private bool turnPossible = true;

    // Start is called before the first frame update
    void Start()
    {
        turnPointObject = GameObject.Find("CarTurningPoint");
        turnPoint = turnPointObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Vector3.Distance(turnPointObject.transform.position, transform.position) <= 4 && turnPossible)
        {
            turnPossible = false;
            transform.Rotate(Vector3.up, +90);
        }

        // Destroy car if out of bounds
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

}
