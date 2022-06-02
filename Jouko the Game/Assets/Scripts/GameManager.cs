using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject spawnManager;
    public GameObject player;
    public GameObject cam;
    private DetectCollision collisionDetection;
    private DetectCollision playerGameover;

    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI creditText;
    public GameObject infoBox;
    public Button restartButton;
    public TextMeshProUGUI restartButtonText;
    public Button startButton;
    public Button descriptionButton;
    public GameObject volumeChanger;
    public Image darkOverlay;
    public Image topBar;

    public bool isTimerOn;
    private float currentTime = 0;
    private int score = 0;
    private int winningScore = 5;
    public bool gameActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (collisionDetection.cowCaptured && gameActive)
        {
            UpdateScore(1);
        }

        if (score == winningScore)
        {
            VictoryScreen();
        }

        if (playerGameover.playerDead && gameActive)
        {
            GameOver();
        }
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Cows captured: " + score + "/" + winningScore;
    }

    public void TimerStart()
    {
        isTimerOn = true;
    }

    public void TimerEnded()
    {
        isTimerOn = false;
    }

    void Timer()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (isTimerOn)
        {
            currentTime += 1 * Time.deltaTime;
            if (!gameActive)
            {
                TimerEnded();

                finalTimeText.text = "Your time was: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);        
    }

    public void VictoryScreen()
    {
        spawnManager.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        cam.gameObject.SetActive(false);

        creditText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        darkOverlay.gameObject.SetActive(true);
        topBar.gameObject.SetActive(false);

        gameActive = false;
    }

    public void GameOver()
    {
        spawnManager.gameObject.SetActive(false);
        cam.gameObject.SetActive(false);

        gameoverText.gameObject.SetActive(true);
        creditText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButtonText.text = "Try again";
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        darkOverlay.gameObject.SetActive(true);
        topBar.gameObject.SetActive(false);

        TimerEnded();
        gameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameActive = true;
        collisionDetection = GameObject.Find("Third Person Player").GetComponent<DetectCollision>();
        playerGameover = GameObject.Find("Third Person Player").GetComponent<DetectCollision>();

        darkOverlay.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        descriptionButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        topBar.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        volumeChanger.gameObject.SetActive(false);
        creditText.gameObject.SetActive(false);

        UpdateScore(0);
        TimerStart();
    }

    public void OpenDescription()
    {
        infoBox.gameObject.SetActive(true);
    }

    public void CloseDescription()
    {
        infoBox.gameObject.SetActive(false);
    }
}
