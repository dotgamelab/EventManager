using System;
using System.Reflection;
using System.Collections;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    //-------------- custom events ---------------------

    /// <summary>
    /// Listener event for function() : add funtion by event += functionName ;
    /// </summary>
    public event Action AddToListener_0_Param;

    /// <summary>
    /// Listener event for function(object data) : add funtion by event += functionName ;
    /// </summary>
    public event Action<object> AddToListener_1_Param;

    /// <summary>
    /// Listener event for function(object data 1 , object data 2) : add funtion by event += functionName ;
    /// </summary>
    public event Action<object, object> AddToListener_2_Param;

    /// <summary>
    /// Listener event for function(object data 1 , object data 2,, object data 3) : add funtion by event += functionName ;
    /// </summary>
    public event Action<object, object, object> AddToListener_3_Param;

    /// <summary>
    /// Listener event for function(object data 1 , object data 2,, object data 3,, object data 4) : add funtion by event += functionName ;
    /// </summary>
    public event Action<object, object, object, object> AddToListener_4_Param;

    /// <summary>
    /// Listener event for IEnumerator function() : add IEnumerator funtion by event += functionName ;
    /// </summary>
    public event Func<IEnumerator> AddToListener_Coroutine_0_Param;

    /// <summary>
    /// Listener event for IEnumerator function(object data 1) : add IEnumerator funtion by event += functionName ;
    /// </summary>
    public event Func<object, IEnumerator> AddToListener_Coroutine_1_Param;

    //--------------------------------------------------------------

    /// <summary>
    /// Call all the functions registerd to the event system
    /// </summary>
    public void TriggerEvent(string functionName) 
    {
        if (AddToListener_0_Param == null)
        {
            Debug.Log("Error : No Registered Function Name Like " + functionName);
            return;
        }

        // invoke subscribed functions with no prarameter
        foreach (Delegate del in AddToListener_0_Param.GetInvocationList())
        {
            if (del.Method.Name == functionName)
            {
                Type thisType = del.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);
                theMethod?.Invoke(del.Target, null);
            }
        }
    }


    /// <summary>
    /// Call all the functions registerd to the event system
    /// </summary>
    public void TriggerEvent(string functionName, object data) 
    {
        if (AddToListener_1_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // invoke subscribed functions with 1 data prarameter
        foreach (Delegate del in AddToListener_1_Param.GetInvocationList())
        {
            if (del.Method.Name == functionName)
            {
                Type thisType = del.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[] { typeof(object) }, null);

                theMethod?.Invoke(del.Target, new object[] { data });
            }
        }
    }


    /// <summary>
    ///  Call all the functions registerd to the event system
    /// </summary>
    public void TriggerEvent(string functionName, object data1, object data2) 
    {
        if (AddToListener_2_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // invoke subscribed functions with 2 data prarameter
        foreach (Delegate d in AddToListener_2_Param.GetInvocationList())
        {
            if (d.Method.Name == functionName)
            {
                Type thisType = d.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[] { typeof(object), typeof(object) }, null);

                theMethod?.Invoke(d.Target, new object[] { data1, data2 });
            }
        }
    }


    /// <summary>
    /// Call all the functions registerd to the event system
    /// </summary>
    public void TriggerEvent(string functionName, object data1, object data2, object data3) 
    {
        if (AddToListener_3_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // invoke subscribed functions with 3 data prarameter
        foreach (Delegate d in AddToListener_3_Param.GetInvocationList())
        {
            if (d.Method.Name == functionName)
            {
                Type thisType = d.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                    new Type[] { typeof(object), typeof(object), typeof(object) }, null);

                theMethod?.Invoke(d.Target, new object[] { data1, data2, data3 });
            }
        }
    }

    /// <summary>
    /// Call all the functions registerd to the event system
    /// </summary>
    public void TriggerEvent(string functionName, object data1, object data2, object data3, object data4) 
    {
        if (AddToListener_4_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // invoke subscribed functions with 4 data prarameter
        foreach (Delegate d in AddToListener_4_Param.GetInvocationList())
        {
            if (d.Method.Name == functionName)
            {
                Type thisType = d.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                    new Type[] { typeof(object), typeof(object), typeof(object), typeof(object) }, null);

                theMethod?.Invoke(d.Target, new object[] { data1, data2, data3, data4 });
            }
        }
    }


    /// <summary>
    /// Call all the IEnumerator Coroutines that you want to run by event system
    /// </summary>
    public void TriggerEvent_StartCoroutine(string functionName) 
    {
        //Debug.Log("ttt1");
        if (AddToListener_Coroutine_0_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // IEnumerator Coroutine - invoke subscribed functions with no data prarameter
        foreach (Delegate del in AddToListener_Coroutine_0_Param.GetInvocationList())
        {
            if (del.Method.Name == functionName)
            {
                Type thisType = del.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);

                StartCoroutine((IEnumerator)theMethod?.Invoke(del.Target, null));
            }
        }
    }


    /// <summary>
    /// Call all the IEnumerator Coroutines that you want to run by event system
    /// </summary>
    public void TriggerEvent_StartCoroutine(string functionName, object data) 
    {
        if (AddToListener_Coroutine_1_Param == null)
        {
            Debug.Log("Error : No Exist Any Registered Function Name Like " + functionName);
            return;
        }

        // IEnumerator Coroutine - invoke subscribed functions with 1 data prarameter
        foreach (Delegate del in AddToListener_Coroutine_1_Param.GetInvocationList())
        {
            if (del.Method.Name == functionName)
            {
                Type thisType = del.Target.GetType();

                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

                MethodInfo theMethod = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[] { typeof(object) }, null);

                StartCoroutine((IEnumerator)theMethod?.Invoke(del.Target, new object[] { data }));
            }
        }
    }

}
