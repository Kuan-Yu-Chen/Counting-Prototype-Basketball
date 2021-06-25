using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillPower : MonoBehaviour
{
    private Image powerImage;
    private bool isPowering = false;
    private float powerAdd = 50;
    private const float TOTAL_POWER = 100;
    private float currentPower = 0;
    private int powerDeter = 0;
    private PlayerControll playerControl;
    private GameManager gameManager;
    public float shootPower;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerControl = GameObject.Find("Player").GetComponent<PlayerControll>();
        powerImage = GameObject.Find("Power Filled").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            if (powerDeter == 1)
            {
                if (isPowering)
                {
                    currentPower = 0;
                    powerImage.fillAmount = currentPower / TOTAL_POWER;
                    isPowering = false;
                }
                fillPowerBar();
                powerImage.fillAmount = currentPower / TOTAL_POWER;
            }
            else if (powerDeter == 2)
            {
                playerControl.shootBall();
                shootPower = powerImage.fillAmount;
                activePower();
                isPowering = true;
            }
        }
        
    }


    public void fillPowerBar() {
        currentPower += powerAdd * Time.deltaTime;
        if (currentPower > TOTAL_POWER) {
            currentPower = 0;
        }
    }

    public void activePower() {
        powerDeter = (powerDeter + 1) % 3;
    }
 
}
