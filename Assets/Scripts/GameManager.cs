using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    public int difficulty;
    private int boxNum = 3;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject countScreen;
    [SerializeField] GameObject basket;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive) {
            if (boxNum == 0)
            {
                GameOver();
            }
        } 
    }

    public void StartGame(int difficulty) {
        isGameActive = true;
        this.difficulty = difficulty;
        titleScreen.gameObject.SetActive(false);
        countScreen.gameObject.SetActive(true);
        basket.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
    }

    public void TargetClear() {
        boxNum -= 1;
    }

    public void GameOver() {
        isGameActive = false;
        countScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        TextMeshProUGUI gameOverText = GameObject.Find("GameOver Text").GetComponent<TextMeshProUGUI>();
        if (boxNum == 0)
        {
            gameOverText.text = "Congratulations";
        }
        else 
        {
            gameOverText.text = "Game Over";
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
