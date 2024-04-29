using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource sound;
    float thrustSpeed = 700;
    float rotateSpeed = 35;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();

        Debug.Log("Welcome to Cock Rocket!");
        Debug.Log("Use SPACE to thrust. Left and Right to turn.");
    }

    // Update is called once per frame
    void Update()
    {
      thrustProcess();
      rotateProcess();
    }

    void thrustProcess()
    {
        if (Input.GetKey(KeyCode.Space))
        {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else
        {
            sound.Stop();
        }
    }

    void rotateProcess()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
