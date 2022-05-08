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

    private void RunEvents() //--------- broadcast messages to all subscribers in the game scene
    {
        EventManager.Instance.TriggerEvent("DoSomething");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ", " my data 2 ");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ", " my data 2 ", " my data 3 ");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ", " my data 2 ", " my data 3 ", " my data 4 ");
        EventManager.Instance.TriggerEvent_StartCoroutine("SubscribedMyCoroutin");
        EventManager.Instance.TriggerEvent_StartCoroutine("SubscribedMyCoroutin", "5");
    }

    private void RunDirectMessage() //--------- send direct message to the target GameObject
    {
        
        GameObject target = GameObject.Find("Target Object"); // fined target GameObject in the Game Scene

        MessageManager.Instance.SendMessage(target, "Damage", 10); // send to GameObject

        MessageManager.Instance.SendMessage(target.GetComponent<TargetAgent>(), "Damage", 20); // send to specified component

        MessageManager.Instance.SendMessageToChildren(target, "Damage", 30); // send to GameObject childiins

        MessageManager.Instance.SendMessageUpwards(target, "Damage", 40); // send to GameObject

        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin"); // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin", 5); // send to Coroutine


        MessageManager.Instance.StartCoroutine(target, "MyCoroutin"); // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target, "MyCoroutin", 255); // send to Coroutine

        MessageManager.Instance.StopCoroutine(target, "MyCoroutin"); // stop Coroutine

        MessageManager.Instance.StartCoroutine<Transform>(target.transform, "MyCoroutin"); // send to Coroutine no param 

        MessageManager.Instance.StartCoroutine<Transform>(target.transform, "MyCoroutin", "Run Coroutine"); // send to Coroutine 
    }
}
