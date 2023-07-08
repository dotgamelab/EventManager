using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAgent : MonoBehaviour
{

    void Damage()
    {
        Debug.Log(" damage");
    }

    void Damage(object damage)
    {
        Debug.Log(" damage  : " + damage);
    }

    void Damage(int damage)
    {
        Debug.Log(" damage  : " + damage);
    }

    void Damage(float damage)
    {
        Debug.Log(" damage  : " + damage);
    }

    //--------------------

    IEnumerator MyCoroutine()
    {
        Debug.Log("Start simple coroutin ");

        yield return null;
    }

    IEnumerator MyCoroutine(string data)
    {
        Debug.Log("Start simple coroutine (string) " + data.ToString());

        yield return null;
    }

    IEnumerator MyCoroutine(int data)
    {
        Debug.Log("Start simple coroutine (int) " + data.ToString());

        yield return null;
    }
}
