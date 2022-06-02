using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private DetectCollision collisionDetection;

    public AudioClip cowCaptureSound;
    private float sfxVolume = 10f;
    private AudioSource playerAudio;
    private bool isTimerOn;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        collisionDetection = GameObject.Find("Third Person Player").GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        isTimerOn = GameObject.Find("Game Manager").GetComponent<GameManager>().isTimerOn;

        if (collisionDetection.cowCaptured && isTimerOn == true)
        {
            playerAudio.PlayOneShot(cowCaptureSound, sfxVolume);
        }
        
    }
}
