using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    public float speed = 1f;
    private int direction = -1;
    public TMP_Text stateText;
    public float targetTime = 0.5f;
    public float targetTimeCopy;
    public bool isOnCheckPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        targetTimeCopy = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            direction *= -1;
            targetTime = targetTimeCopy;
        }

        if (isOnCheckPoint)
        {
            stateText.text = "Checking";
        }
        else
        {
            stateText.text = "Walking";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BossCheckPoint")
        {
            isOnCheckPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BossCheckPoint")
        {
            isOnCheckPoint = false;
        }
    }
}
