using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftController : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 90.00f;

    [SerializeField]
    private float rollControlSensitivity = 0.2f;
    
    [SerializeField]
    private float pitchControlSensitivity = 0.2f;

    [SerializeField]
    private float yawControlSensitivity = 0.2f;

    [SerializeField]
    private float thrustControlSensitivity = 0.01f;

    float roll;
    float pitch;
    float yaw;

    float thrustPr;
    

    // Start is called before the first frame update
    void Start()
    {
        SetThrust(0);
    }

    private void SetThrust(float percent) {
        thrustPr = Mathf.Clamp01(percent);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SetThrust(thrustPr + thrustControlSensitivity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            thrustControlSensitivity *= -1;
        }

        pitch = pitchControlSensitivity * Input.GetAxisRaw("Vertical");
        roll = rollControlSensitivity * Input.GetAxisRaw("Horizontal");
        yaw = yawControlSensitivity * Input.GetAxisRaw("Yaw");

    }

    private void FixedUpdate()
    {
        

        transform.position += transform.forward * Time.deltaTime * (thrustPr + thrustControlSensitivity) * speed;
        speed -= transform.forward.y * Time.deltaTime * 90.0f;

        if (speed < 40.0f)
        {
            speed = 40.0f;
        }

        //transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), -Input.GetAxis("Horizontal"));
        transform.Rotate(pitch, yaw, -roll);

        float terHeightCompare = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terHeightCompare > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terHeightCompare, transform.position.z);
        }
    }
}
