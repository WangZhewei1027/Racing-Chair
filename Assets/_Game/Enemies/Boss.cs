using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    public float speed = 1f;
    private int direction = -1;
    private GameObject desk;
    public TMP_Text stateText;

    // Start is called before the first frame update
    void Start()
    {
        desk = GameObject.FindGameObjectWithTag("ComputerDesk");
        EventManager.Check += check;
        EventManager.UnCheck += unCheck;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
        float dist = Vector3.Distance(transform.position, desk.transform.position);
        if (dist > 10)
        {
            direction *= -1;
        }
    }

    
    private void check()
    {

        stateText.text = "Checking";
    }
    private void unCheck()
    {
        stateText.text = "Walking";
    }

}
