using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlying : MonoBehaviour
{
    private Rigidbody ballRb;
    [SerializeField] float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddRelativeForce(Vector3.up * getShootPower() * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float getShootPower() {
        return GameObject.Find("Power Control").GetComponent<FillPower>().shootPower;
    }
}
