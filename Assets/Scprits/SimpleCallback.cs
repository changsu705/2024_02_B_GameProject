using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCallback : MonoBehaviour
{
    private Action greetingAction;

    void Start()
    {
        greetingAction = SayHello;
        PerformGreeting(greetingAction);
    }

    void SayHello()
    {
        Debug.Log("Hello, wolrd!");
    }

    void PerformGreeting (Action greetingFunc)
    {
        greetingFunc?.Invoke();
    }

}
