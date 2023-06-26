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

    IEnumerator MyCoroutin()
    {
        Debug.Log("Start simple coroutin ");

        yield return null;
    }

    IEnumerator MyCoroutin(string data)
    {
        Debug.Log("Start simple coroutin (string) " + data.ToString());

        yield return null;
    }

    IEnumerator MyCoroutin(int data)
    {
        Debug.Log("Start simple coroutin (int) " + data.ToString());

        yield return null;
    }
}
