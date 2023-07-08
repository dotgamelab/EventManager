# Unity Game EventManager 
An Event Manager system for unity game projects based on C# events and Reflections.

 + Subscriber Example :
```cs
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
    private void OnDoSomething()
    {
        Debug.Log(" Subscribe Event with 0 data parameter");
    }
    IEnumerator OnSubscribedMyCoroutin(object data)
    {
        Debug.Log("Subscribed Event function - Start coroutine " + data.ToString());

        yield return null;
    }

```
+ Publisher Example :
```cs
 EventManager.Instance.TriggerEvent("OnDoSomething");
 EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin");
 EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin", "YourData");
```
-----------------------------------------------------------------------------------------
Send Message to a GameObject Example
```cs
 MessageManager.Instance.SendMessage(_target, "Damage", 10);

// send message to Coroutine with specified component on the target gameObject - 1 param 
 MessageManager.Instance.StartCoroutine(_target.GetComponent<TargetAgent>(), "MyCoroutin", 5);
 // send message to Coroutine on the target gameObject - no param 
 MessageManager.Instance.StartCoroutine(_target, "MyCoroutin");
```
