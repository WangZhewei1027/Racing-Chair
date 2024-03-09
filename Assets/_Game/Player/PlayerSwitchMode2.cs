using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSwitchMode2 : MonoBehaviour
{
    public bool isOnCheckPoint = false;
    public bool isWorking = false;
    public TMP_Text stateText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCheckPoint)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isWorking = !isWorking;
            }
        }
        if (isWorking)
        {
            stateText.text = "Working";
        }
        else
        {
            if (isOnCheckPoint)
            {
                stateText.text = "Press E";
            }
            else
            {
                stateText.text = "Racing";
            }
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
