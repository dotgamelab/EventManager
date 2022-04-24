using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to Event
        EventManager.Instance.AddToListener_0_Param += DoSomething;
        EventManager.Instance.AddToListener_1_Param += DoSomething;
        EventManager.Instance.AddToListener_2_Param += DoSomething;
        EventManager.Instance.AddToListener_3_Param += DoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param += SubscribedMyCoroutin;
        EventManager.Instance.AddToListener_Coroutine_1_Param += SubscribedMyCoroutin;
    }

    private void OnDestroy() // UnSubscribe to Event
    {
        EventManager.Instance.AddToListener_0_Param -= DoSomething;
        EventManager.Instance.AddToListener_1_Param -= DoSomething;
        EventManager.Instance.AddToListener_2_Param -= DoSomething;
        EventManager.Instance.AddToListener_3_Param -= DoSomething;

        EventManager.Instance.AddToListener_Coroutine_0_Param -= SubscribedMyCoroutin;
        EventManager.Instance.AddToListener_Coroutine_1_Param -= SubscribedMyCoroutin;
    }

    private void DoSomething()
    {
        Debug.Log(" Hi EveryOne ");
    }
    private void DoSomething(object data)
    {
        Debug.Log(" Hi EveryOne " + data.ToString());
    }
    private void DoSomething(object data1, object data2)
    {
        Debug.Log(" Hi EveryOne " + data1.ToString() + data2.ToString());
    }
    void DoSomething(object data1, object data2, object data3)
    {
        Debug.Log(" Hi EveryOne " + data1.ToString() + data2.ToString() + data3.ToString());
    }

    void DoSomeThingDirect()
    {
        Debug.Log("Direct Message");
    }


    IEnumerator SubscribedMyCoroutin()
    {
        Debug.Log("Start coroutin");

        yield return null;
    }

    IEnumerator SubscribedMyCoroutin(object data)
    {
        Debug.Log("Start coroutin " + data.ToString());

        yield return null;
    }
}