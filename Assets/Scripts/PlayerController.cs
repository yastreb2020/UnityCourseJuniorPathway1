using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // private variables
    private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 30f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // getting input
        horizontalInput = Input.GetAxis("Horizontal" + this.name);
        forwardInput = Input.GetAxis("Vertical"+ this.name);

        // Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        // rotate the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        speed = playerRb.velocity.magnitude * 3.6f; //kph, for mph use 2.237f
        speedometerText.SetText("Speed: " + Mathf.RoundToInt(speed) + " km/h");
    }
}
