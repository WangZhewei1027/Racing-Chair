using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    private Rigidbody rb;
    public float maxVelocity = 20;
    public TMP_Text stateText;
    private Animator mAnimator;
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => Move();

    }

    void Move()
    {
        print("dfadadf");

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (stateText.text != "Working")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(new Vector3(force * -1, 0, 0));
                mAnimator.SetTrigger("Racing");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(new Vector3(force, 0, 0));
                mAnimator.SetTrigger("Racing");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, 0, force * -1));
                mAnimator.SetTrigger("Racing");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, 0, force));
                mAnimator.SetTrigger("Racing");
            }
            if (transform.position.y < -10)
            {
                CanvasController.whoWin = "Player 2";
                EventManager.Win();
            }
            if (rb.velocity.sqrMagnitude > maxVelocity)
            {
                rb.velocity *= 0.99f;
            }
        }
        if (stateText.text == "Working")
        {
            mAnimator.SetTrigger("Working");
        }
        else
        {
            mAnimator.SetTrigger("Idle");
        }
    }
}
