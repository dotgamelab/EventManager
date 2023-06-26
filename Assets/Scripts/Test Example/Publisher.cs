using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Publisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RunEvents();

        //--------------

        RunMessage();
    }

    //--------- run all registered events 
    private void RunEvents()
    {
        EventManager.Instance.TriggerEvent("OnDoSomething");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ");
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", 10);
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", " my data 2 ", 56.54f);
        EventManager.Instance.TriggerEvent("OnDoSomething", " my data 1 ", " my data 2 ", " my data 3 ", PlayerState.Idle);
        EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin");
        EventManager.Instance.TriggerEvent_StartCoroutine("OnSubscribedMyCoroutin", "5");
    }

    //--------- send message to the target GameObject
    private void RunMessage()
    {
        // fined target GameObject in the Game Scene
        GameObject target = GameObject.Find("Target Object");

        //---------------------

        // send to GameObject
        MessageManager.Instance.SendMessage(target, "Damage", 10);

        // send to specified component
        MessageManager.Instance.SendMessage(target.GetComponent<TargetAgent>(), "Damage", 20);

        // send to GameObject childiins
        MessageManager.Instance.SendMessageToChildren(target, "Damage", 30);

        // send to GameObjects - Upwards
        MessageManager.Instance.SendMessageUpwards(target, "Damage", 40);

        // broadcast to all GameObjects in the scene
        MessageManager.Instance.BroadCastMessage("Damage");

        // broadcast to all GameObjects in the scene - Generic version (int) - automaticlly detect proper type as data value
        MessageManager.Instance.BroadCastMessage("Damage", 1000);

        // broadcast to all GameObjects in the scene - Generic version (float)
        MessageManager.Instance.BroadCastMessage<float>("Damage", 2000.5f);

        // broadcast to all GameObjects in the scene - Generic version (string)
        MessageManager.Instance.BroadCastMessage<string>("Damage", " do damage");

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin");
        // send to Coroutine
        MessageManager.Instance.StartCoroutine(target.GetComponent<TargetAgent>(), "MyCoroutin", 5);

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target, "MyCoroutin");
        // send to Coroutine
        MessageManager.Instance.StartCoroutine(target, "MyCoroutin", 255);

        // stop Coroutine
        MessageManager.Instance.StopCoroutine(target, "stop MyCoroutin");

        // send to Coroutine no param 
        MessageManager.Instance.StartCoroutine(target.transform, "MyCoroutin");

        // send to Coroutine 
        MessageManager.Instance.StartCoroutine(target.transform, "MyCoroutin", "Run Coroutine");
    }
}
