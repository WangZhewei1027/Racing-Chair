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
    public GameObject player, player2, target;

    // Start is called before the first frame update
    void Start()
    {
        targetTimeCopy = targetTime;
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
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
            if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
            {
                if (!PlayerSwitchMode.isWorking)
                {
                    CanvasController.whoWin = "Player1 caught by Boss, Player2";
                    EventManager.Win();
                }
            }
            if (Vector3.Distance(player2.transform.position, this.transform.position) < 3)
            {
                if (!PlayerSwitchMode2.isWorking)
                {
                    CanvasController.whoWin = "Player2 caught by Boss, Player1";
                    EventManager.Win();
                }
            }
        }
        else
        {
            stateText.text = "Walking";
        }

        if(Vector3.Distance(player.transform.position,this.transform.position)< Vector3.Distance(player.transform.position, this.transform.position))
        {
            target = player;
        }

        if(Vector3.Distance(target.transform.position, this.transform.position)<30)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1);
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
