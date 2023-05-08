using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RunEvents();
        RunDirectMessage();
    }

    //--------- broadcast messages to all subscribers in the game scene
    private void RunEvents()
    {
        EventManager.Instance.TriggerEvent("OnDoSomething");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", " my data 2 ");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", " my data 2 ", " my data 3 ");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", " my data 2 ", " my data 3 ", " my data 4 ");
        EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin");
        EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin", "5");
    }

    //--------- send direct message to the target GameObject
    private void RunDirectMessage() 
    {
        // fined target GameObject in the Game Scene
        GameObject target = GameObject.Find("Target Object");

        // send to GameObject
        MessageManager.Instance.SendMessage(target, "Damage", 10);

        // send to specified component
        MessageManager.Instance.SendMessage(target.GetComponent<TargetAgent>(), "Damage", 20);

        // send to GameObject childiins
        MessageManager.Instance.SendMessageToChildren(target, "Damage", 30);

        // send to GameObjects - Upwards
        MessageManager.Instance.SendMessageUpwards(target, "Damage", 40);

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin");
        // send to Coroutine
        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin", 5);

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target, "MyCoroutin");
        // send to Coroutine
        MessageManager.Instance.StartCoroutine(target, "MyCoroutin", 255);

        // stop Coroutine
        MessageManager.Instance.StopCoroutine(target, "MyCoroutin");

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine<Transform>(target.transform, "MyCoroutin");

        // send to Coroutine 
        MessageManager.Instance.StartCoroutine<Transform>(target.transform, "MyCoroutin", "Run Coroutine"); 
    }
}
