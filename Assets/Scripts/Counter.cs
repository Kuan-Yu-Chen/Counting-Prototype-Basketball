using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    private GameManager gameManager;
    private int Count;
    private bool targetClear = false;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Count = gameManager.difficulty;
        CounterText.text = "Target : " + Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!targetClear) {
            Count -= 1;
            CounterText.text = "Target : " + Count;
            if (Count == 0)
            {
                gameManager.TargetClear();
                targetClear = true;
            }
        }
    }
}
