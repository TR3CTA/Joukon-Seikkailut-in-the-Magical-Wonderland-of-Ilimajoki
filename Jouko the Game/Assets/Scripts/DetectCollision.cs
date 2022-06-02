using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool cowCaptured = false;
    public bool playerDead = false;

    // Update is called once per frame
    void Update()
    {
        cowCaptured = false;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cow" && this.gameObject.tag == "Player")
        {
            cowCaptured = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Cow" && this.gameObject.tag == "Building")
        {
            collision.gameObject.transform.Rotate(Vector3.up, +180f);
        }

        if (collision.gameObject.tag =="Cow" && this.gameObject.tag == "Car")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Car" && this.gameObject.tag == "Player")
        {
            playerDead = true;
            Destroy(this.gameObject);
        }
    }
}
