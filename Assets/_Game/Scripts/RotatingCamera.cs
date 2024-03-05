using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    public float rotateTime = 0.2f;
    private GameObject player;
    private bool isRotating = false;
    private float ax, az, ix, iy, iz;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ax = player.transform.position.x;
        az = player.transform.position.z;
        ix = this.transform.position.x;
        iy = this.transform.position.y;
        iz = this.transform.position.z;
    }

    void Update()
    {
        float dx = player.transform.position.x - ax;
        float dz = player.transform.position.z - az;

        this.transform.position = new Vector3(ix + dx, iy, iz + dz);

        //Rotate();
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotateAround(-45, rotateTime));
        }
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateAround(45, rotateTime));
        }
    }

    IEnumerator RotateAround(float angel, float time)
    {
        float number = 60 * time;
        float nextAngel = angel / number;
        isRotating = true;

        for (int i = 0; i < number; i++)
        {
            transform.Rotate(new Vector3(0, nextAngel, 0));
            yield return new WaitForFixedUpdate();
        }

        isRotating = false;
    }
}
