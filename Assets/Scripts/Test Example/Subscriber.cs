using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber : MonoBehaviour
{
    void OnEnable()
    {
        // Subscribe to Events
        EventManager.Instance.AddToListener_0_Param += OnDoSomething;
        EventManager.Instance.AddToListener_1_Param += OnDoSomething;
        EventManager.Instance.AddToListener_2_Param += OnDoSomething;
        EventManager.Instance.AddToListener_3_Param += OnDoSomething;
        EventManager.Instance.AddToListener_4_Param += OnDoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param += OnSubscribedMyCoroutine;
        EventManager.Instance.AddToListener_Coroutine_1_Param += OnSubscribedMyCoroutine;
    }

    
    private void OnDisable() 
    {
        if (!this.gameObject.scene.isLoaded) return;

        // UnSubscribe

        EventManager.Instance.AddToListener_0_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_1_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_2_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_3_Param -= OnDoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param -= OnSubscribedMyCoroutine;
        EventManager.Instance.AddToListener_Coroutine_1_Param -= OnSubscribedMyCoroutine;
    }

    private void OnDoSomething()
    {
        Debug.Log("Subscribed Event function with 0 data parameter");
    }

    private void OnDoSomething(object data)
    {
        Debug.Log("Subscribed Event function with 1 data parameter " + data.ToString());
    }

    private void OnDoSomething(object data1, object data2)
    {
        Debug.Log("Subscribed Event function with 2 data parameter " + data1.ToString() + data2.ToString());
    }

    void OnDoSomething(object data1, object data2, object data3)
    {
        Debug.Log("Subscribed Event function with 3 data parameter " + data1.ToString() + data2.ToString() + data3.ToString());
    }

    void OnDoSomething(object data1, object data2, object data3, object data4)
    {
        // Cast data arg to proper enums type
        PlayerState playerState = (PlayerState)data4;

        Debug.Log("Subscribed Event function with 4 data parameter " + data1.ToString() + data2.ToString() + data3.ToString() + playerState);
    }

    IEnumerator OnSubscribedMyCoroutine()
    {
        Debug.Log("Subscribed Event function - Start coroutine with 0 param");

        yield return null;
    }

    IEnumerator OnSubscribedMyCoroutine(object data)
    {
        Debug.Log("Subscribed Event function - Start coroutine with 1 param " + data.ToString());

        yield return null;
    }

    void OnDoSomeThingDirect()
    {
        Debug.Log("Direct Message");
    }
}