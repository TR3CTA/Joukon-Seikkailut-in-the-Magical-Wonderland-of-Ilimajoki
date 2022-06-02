using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private Animator playerAnim;

    private float speed = 10;

    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float boundaryRange = 62f;

    private bool gameActive;

    private void Start()
    {
        playerAnim = GameObject.Find("Character_Male_Jacket_01").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameActive = GameObject.Find("Game Manager").GetComponent<GameManager>().gameActive;

        // Make player move and turn directions
        float forwardInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0f, forwardInput).normalized;


        if (direction.magnitude >= 0.1f && gameActive)
        {
            playerAnim.SetBool("Run_Trig", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (direction.magnitude < 0.1f)
        {
            playerAnim.SetBool("Run_Trig", false);
        }

        // Keep the player in bounds
        // Western boundary
        if (transform.position.x < -boundaryRange)
        {
            transform.position = new Vector3(-boundaryRange, transform.position.y, transform.position.z);
        }
        // Eastern boundary
        if (transform.position.x > boundaryRange)
        {
            transform.position = new Vector3(boundaryRange, transform.position.y, transform.position.z);
        }
        // Southern boundary
        if (transform.position.z < -boundaryRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundaryRange);
        }
        // Northern boundary
        if (transform.position.z > boundaryRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundaryRange);
        }
    }
}
