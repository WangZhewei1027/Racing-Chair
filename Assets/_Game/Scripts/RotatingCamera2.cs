using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera2 : MonoBehaviour
{
    public float rotateTime = 0.2f;
    private GameObject player;
    private float ax, az, ix, iy, iz;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player2");
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
    }
}
