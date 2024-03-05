using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector3(force * -1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector3(force, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, force * -1));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, force));
        }
        if (transform.position.y < -10)
        {
            CanvasController.whoWin = "Player 2";
            EventManager.Win();
        }
    }
}
