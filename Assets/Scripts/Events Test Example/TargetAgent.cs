using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAgent : MonoBehaviour
{

    void Damage()
    {
        Debug.Log(" damage : ");
    }

    void Damage(object damage)
    {
        Debug.Log(" damage : " + (int)damage + " " + gameObject.name);
    }

    //--------------------

    IEnumerator MyCoroutin()
    {
        Debug.Log("Start simple coroutin ");

        yield return null;
    }

    IEnumerator MyCoroutin(object data)
    {
        Debug.Log("Start simple coroutin " + data.ToString());

        yield return null;
    }
}
