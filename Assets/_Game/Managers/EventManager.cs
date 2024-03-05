using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action Check;
    public static event Action UnCheck;
    public static event Action isWin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StartCheck()
    {
        Check?.Invoke();
    }
    public static void StopCheck()
    {
        UnCheck?.Invoke();
    }
    public static void Win()
    {
        isWin?.Invoke();
    }
}
