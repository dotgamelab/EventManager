using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Publisher : MonoBehaviour
{
    private GameObject _target; // target GameObject in the scene

    void Start()
    {
        if (_target == null)
        {
            // fined target GameObject in the Game Scene
            _target = GameObject.Find("Target GameObject");
        }

        //--------------

        RunEvents();

        //--------------

        RunMessages();
    }

    //--------- Run Registered Events 
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

    //--------- Send Message to the target GameObject
    private void RunMessages()
    {
        // send message to the GameObject
        MessageManager.Instance.SendMessage(_target, "Damage", 10);

        // send message to specified component on the target gameObject
        MessageManager.Instance.SendMessage(_target.GetComponent<TargetAgent>(), "Damage", 20);

        // send message to the GameObject children's
        MessageManager.Instance.SendMessageToChildren(_target, "Damage", 30);

        // send message to the GameObjects - Upwards
        MessageManager.Instance.SendMessageUpwards(_target, "Damage", 40);

        // broadcast message to all GameObjects in the scene
        MessageManager.Instance.BroadCastMessage("Damage");

        // broadcast message to all GameObjects in the scene - Generic version (int) - automaticlly detect proper type as data value
        MessageManager.Instance.BroadCastMessage("Damage", 1000);

        // broadcast message to all GameObjects in the scene - Generic version (float) - automaticlly detect proper type as data value
        MessageManager.Instance.BroadCastMessage("Damage", 2000.5f);

        // broadcast message to all GameObjects in the scene - Generic version (string) - - automaticlly detect proper type as data value
        MessageManager.Instance.BroadCastMessage("Damage", "your data");

        // send message to Coroutine with specified component on the target gameObject - no param 
        MessageManager.Instance.StartCoroutine(_target.GetComponent<TargetAgent>(), "MyCoroutin");

        // send message to Coroutine with specified component on the target gameObject - 1 param 
        MessageManager.Instance.StartCoroutine(_target.GetComponent<TargetAgent>(), "MyCoroutin", 5);

        // send message to Coroutine on the target gameObject - no param 
        MessageManager.Instance.StartCoroutine(_target, "MyCoroutin");

        // send message to Coroutine on the target gameObject - 1 param
        MessageManager.Instance.StartCoroutine(_target, "MyCoroutin", 255);

        // stop Coroutine on the target gameObject
        MessageManager.Instance.StopCoroutine(_target, "MyCoroutin");

        // send message to Coroutine no param - send to the gameobject component
        MessageManager.Instance.StartCoroutine(_target.transform, "MyCoroutin");

        // send message to Coroutine 1 param - send to the gameobject component
        MessageManager.Instance.StartCoroutine(_target.transform, "MyCoroutin", "Run Coroutine");
    }
}
