using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber : MonoBehaviour
{
    void OnEnable()
    {
        // Subscribe Events
        EventManager.Instance.AddToListener_0_Param += OnDoSomething;
        EventManager.Instance.AddToListener_1_Param += OnDoSomething;
        EventManager.Instance.AddToListener_2_Param += OnDoSomething;
        EventManager.Instance.AddToListener_3_Param += OnDoSomething;
        EventManager.Instance.AddToListener_4_Param += OnDoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param += OnSubscribedMyCoroutin;
        EventManager.Instance.AddToListener_Coroutine_1_Param += OnSubscribedMyCoroutin;
    }

    
    private void OnDisable() 
    {
        if (!this.gameObject.scene.isLoaded) return;

        // UnSubscribe Events

        EventManager.Instance.AddToListener_0_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_1_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_2_Param -= OnDoSomething;
        EventManager.Instance.AddToListener_3_Param -= OnDoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param -= OnSubscribedMyCoroutin;
        EventManager.Instance.AddToListener_Coroutine_1_Param -= OnSubscribedMyCoroutin;
    }

    private void OnDoSomething()
    {
        Debug.Log(" Subscribe Event with 0 data parameter");
    }
    private void OnDoSomething(object data)
    {
        Debug.Log(" Subscribe Event " + data.ToString());
    }
    private void OnDoSomething(object data1, object data2)
    {
        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString());
    }
    void OnDoSomething(object data1, object data2, object data3)
    {
        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString() + data3.ToString());
    }

    void OnDoSomething(object data1, object data2, object data3, object data4)
    {
        // Cast data arg to proper enums type
        PlayerState playerState = (PlayerState)data4;

        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString() + data3.ToString() + playerState);
    }

    void OnDoSomeThingDirect()
    {
        Debug.Log("Direct Message");
    }


    IEnumerator OnSubscribedMyCoroutin()
    {
        Debug.Log("Subscribed Event function - Start coroutine with 0 param");

        yield return null;
    }

    IEnumerator OnSubscribedMyCoroutin(object data)
    {
        Debug.Log("Subscribed Event function - Start coroutine " + data.ToString());

        yield return null;
    }
}