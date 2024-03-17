using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    private Rigidbody rb;
    public float maxVelocity = 20;
    public TMP_Text stateText;
    private Animator mAnimator;
    private Vector2 movementInput;
    private bool isOnCheckPoint = false;
    private bool isWorking = false;

    //private MultiplayerControls playerCtrl;

    void Move()
    {
        print("dfadadf");

    }

    void Start()
    {
        //playerCtrl = new MultiplayerControls();
        //playerCtrl.Enable();
        //playerCtrl.Player.Move.performed += Move;

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

        if (isWorking)
        {
            stateText.text = "Working";
        }
        else
        {
            stateText.text = "Racing";
            
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (!isWorking)
        {
            print("1");
            print(movementInput);
            movementInput = ctx.ReadValue<Vector2>();
            rb.AddForce(new Vector3(movementInput.x * 22, 0, movementInput.y * 22));
            mAnimator.SetTrigger("Racing");
        }
    }

    public void Work()
    {
        print("work1");
        if (isOnCheckPoint)
        {
            isWorking = !isWorking;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCheckPoint")
        {
            isOnCheckPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerCheckPoint")
        {
            isOnCheckPoint = false;
        }
    }
}
