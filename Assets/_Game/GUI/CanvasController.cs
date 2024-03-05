using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    private GameObject [] gui;
    public static string whoWin = "Player 1";
    public TMP_Text whoWinText;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        gui = GameObject.FindGameObjectsWithTag("UI");
        gui[0].SetActive(false);
        EventManager.isWin += display;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void display()
    {
        whoWinText.text = whoWin + " Win!";
        gui[0].SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.isWin -= display;
    }
}
