using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber : MonoBehaviour
{
    void OnEnable()
    {
        // Subscribe to Event
        EventManager.Instance.AddToListener_0_Param += DoSomething;
        EventManager.Instance.AddToListener_1_Param += DoSomething;
        EventManager.Instance.AddToListener_2_Param += DoSomething;
        EventManager.Instance.AddToListener_3_Param += DoSomething;
        EventManager.Instance.AddToListener_4_Param += DoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param += SubscribedMyCoroutine;
        EventManager.Instance.AddToListener_Coroutine_1_Param += SubscribedMyCoroutine;
    }

    private void OnDisable() // UnSubscribe to Event
    {
        if (!this.gameObject.scene.isLoaded) return;

        EventManager.Instance.AddToListener_0_Param -= DoSomething;
        EventManager.Instance.AddToListener_1_Param -= DoSomething;
        EventManager.Instance.AddToListener_2_Param -= DoSomething;
        EventManager.Instance.AddToListener_3_Param -= DoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param -= SubscribedMyCoroutine;
        EventManager.Instance.AddToListener_Coroutine_1_Param -= SubscribedMyCoroutine;
    }

    private void DoSomething()
    {
        Debug.Log(" Subscribe Event ");
    }
    private void DoSomething(object data)
    {
        Debug.Log(" Subscribe Event " + data.ToString());
    }
    private void DoSomething(object data1, object data2)
    {
        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString());
    }
    void DoSomething(object data1, object data2, object data3)
    {
        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString() + data3.ToString());
    }

    void DoSomething(object data1, object data2, object data3, object data4)
    {
        Debug.Log(" Subscribe Event " + data1.ToString() + data2.ToString() + data3.ToString() + data4.ToString());
    }

    void DoSomeThingDirect()
    {
        Debug.Log("Direct Message");
    }


    IEnumerator SubscribedMyCoroutine()
    {
        Debug.Log("Subscribe Event - Start coroutine");

        yield return null;
    }

    IEnumerator SubscribedMyCoroutine(object data)
    {
        Debug.Log("Subscribe Event - Start coroutine " + data.ToString());

        yield return null;
    }
}