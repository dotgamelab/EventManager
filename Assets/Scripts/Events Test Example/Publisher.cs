using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //--------- broadcast messages to all subscribers in the game scene

        EventManager.Instance.TriggerEvent("DoSomething");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ", " my data 2 ");
        EventManager.Instance.TriggerEvent("DoSomething", " my data 1 ", " my data 2 ", " my data 3 ");
        EventManager.Instance.TriggerEvent_StartCoroutine("SubscribedMyCoroutin");
        EventManager.Instance.TriggerEvent_StartCoroutine("SubscribedMyCoroutin", "5");


        //--------- send direct message to the GameObject

        GameObject target = GameObject.Find("Target Object"); // fined target GameObject in the Game Scene

        EventManager.Instance.SendMessage(target, "Damage", 10); // send to GameObject

        EventManager.Instance.SendMessage(target.GetComponent<TargetAgent>(), "Damage", 20); // send to specified component

        EventManager.Instance.SendMessageToChildren(target, "Damage", 30); // send to GameObject childiins

        EventManager.Instance.SendMessageUpwards(target, "Damage", 40); // send to GameObject

        EventManager.Instance.SendMessage_StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin"); // send to Coroutine no param 
        EventManager.Instance.SendMessage_StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin", 5); // send to Coroutine

        EventManager.Instance.SendMessage_StartCoroutine(target, "MyCoroutin"); // send to Coroutine no param 
        EventManager.Instance.SendMessage_StartCoroutine(target, "MyCoroutin", 255); // send to Coroutine
    }
}
