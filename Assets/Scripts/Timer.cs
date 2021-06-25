using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private const float TIME_TOTAL = 90.0f;
    private float currentTime;
    private TextMeshProUGUI timerText;
    public bool isTimerRunning = false;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        currentTime = TIME_TOTAL;
        timerText.text = "Timer: " + currentTime;
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning && gameManager.isGameActive) {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                displayTime(currentTime);
            }
            else {
                currentTime = 0;
                isTimerRunning = false;
                gameManager.GameOver();
                displayTime(-1);
            }
        }
        

    }

    void displayTime(float timeToDisplay) {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay);
        timerText.text = "Timer: " + seconds;
    }
}
