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
    private float rpm;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> wheels;

    void Awake()
    {
        //must give each wheel a little torque or the wheel colliders will be stuck/not work properly
        foreach (WheelCollider w in wheels)
            w.motorTorque = 0.000001f;
    }

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

        if (IsOnGround())
        {
            // Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            // rotate the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = playerRb.velocity.magnitude * 3.6f; //kph, for mph use 2.237f
            speedometerText.SetText("Speed: " + Mathf.RoundToInt(speed) + " km/h");
            rpm = speed % 30 * 40;
            rpmText.SetText($"RPM : {rpm}");
        }

    }

    bool IsOnGround() {
        int isGrounded = 0;
        foreach (var wheel in wheels) {
            if (wheel.isGrounded) isGrounded++;
        }

        return isGrounded > 1;
    }
}