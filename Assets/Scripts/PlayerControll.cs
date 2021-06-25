using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 3.0f;
    private float rotSpeed = 100.0f;
    private FillPower fillPower;
    public GameObject ballPrefab;
    private float moveBoundary = 11.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        fillPower = GameObject.Find("Power Control").GetComponent<FillPower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime * -verticalInput);

            if (Mathf.Abs(transform.position.z) >= moveBoundary)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sign(transform.position.z) * moveBoundary);
            }

            Vector3 currentEuler = transform.localRotation.eulerAngles;
            if (currentEuler.z >= 90 && currentEuler.z < 180)
            {
                currentEuler.z = 90;
            }
            else if (currentEuler.z > 270)
            {
                currentEuler.z = 0;
            }

            transform.localRotation = Quaternion.Euler(currentEuler);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                fillPower.activePower();
            }
        }
        
        
    }

    public void shootBall() {
        Instantiate(ballPrefab, this.transform.GetChild(0).position, this.transform.GetChild(0).rotation);
    }
}
