﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float force;
    private Rigidbody rb;
    public float maxVelocity = 20;
    public TMP_Text stateText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (stateText.text != "Working")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(force * -1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(force, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.AddForce(new Vector3(0, 0, force * -1));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(new Vector3(0, 0, force));
            }
            if (transform.position.y < -10)
            {
                CanvasController.whoWin = "Player 1";
                EventManager.Win();
            }
            if (rb.velocity.sqrMagnitude > maxVelocity)
            {
                rb.velocity *= 0.99f;
            }
        }
    }
}
