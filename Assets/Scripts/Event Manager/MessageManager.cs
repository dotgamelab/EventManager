using System;
using System.Reflection;
using System.Collections;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
    /* send & broadcast direct messages system */

    /// <summary>
    /// Send direct message to the target GameObject
    /// </summary>
    public void SendMessage<T>(GameObject target, string functionName, T data)
    {
        if (!target)
            return;

        Component[] getComponents = target.GetComponents<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[] { typeof(T) }, null);

            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    thisTypeMethodinfo?.Invoke(component, new object[] { data });
                }
            }
        }
    }

    /// <summary>
    /// Send direct message to the target GameObject and upward objects
    /// </summary>
    public void SendMessageUpwards<T>(GameObject target, string functionName, T data)
    {
        if (!target)
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[] { typeof(T) }, null);

            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    thisTypeMethodinfo?.Invoke(component, new object[] { data });
                }
            }
        }
    }


    /// <summary>
    /// Send direct message to the taget GameObject component
    /// </summary>
    public void SendMessage<T>(Component targetComponent, string functionName, T data)
    {
        if (!targetComponent)
            return;

        Type thisType = targetComponent.GetType();

        BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

        MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
            new Type[] { typeof(T) }, null);

        foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
        {
            if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
            {
                thisTypeMethodinfo?.Invoke(targetComponent, new object[] { data });
            }
        }
    }


    /// <summary>
    /// Send direct message to the target GameObject and all children 
    /// </summary>
    public void SendMessageToChildren<T>(GameObject target, string functionName, T data)
    {
        if (!target)
            return;

        Component[] getComponentsInChildren = target.GetComponentsInChildren<Component>();

        foreach (Component c in getComponentsInChildren)
        {
            Type thisType = c.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[] { typeof(T) }, null);

            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    thisTypeMethodinfo?.Invoke(c, new object[] { data });
                }
            }
        }
    }

    /// <summary>
    /// BroadCast Message to the all GameObject in the scene 
    /// </summary>
    public void BroadCastMessage(string functionName)
    {
        Component[] getComponents = UnityEngine.Object.FindObjectsOfType<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[0], null);

            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    thisTypeMethodinfo?.Invoke(component, null);
                }
            }
        }
    }

    /// <summary>
    /// BroadCast Message to the all GameObject in the scene 
    /// </summary>
    public void BroadCastMessage<T>(string functionName, T data)
    {
        Component[] getComponents = UnityEngine.Object.FindObjectsOfType<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
                new Type[] { typeof(T) }, null);

            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    thisTypeMethodinfo?.Invoke(component, new object[] { data });
                }
            }
        }
    }

    /// <summary>
    /// Call the IEnumerator Coroutines 
    /// </summary>
    public void StartCoroutine(Component targetComponent, string functionName)
    {
        if (!targetComponent)
            return;

        Type thisType = targetComponent.GetType();

        BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

        MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);

        // invoke IEnumerators with no prarameter
        foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
        {
            if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
            {
                StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(targetComponent, null));
            }
        }
    }

    /// <summary>
    /// Call the IEnumerator Coroutines 
    /// </summary>
    public void StartCoroutine(GameObject target, string functionName)
    {
        if (!target)
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);

            // invoke IEnumerators with no prarameter
            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(component, null));
                }
            }
        }
    }

    /// <summary>
    /// Calls the IEnumerator Coroutines and send a one data arg
    /// </summary>
    public void StartCoroutine<T>(Component targetComponent, string functionName, T data)
    {
        if (!targetComponent)
            return;

        Type thisType = targetComponent.GetType();

        BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

        MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
            new Type[] { typeof(T) }, null);

        // invoke IEnumerators with 1 data prarameter
        foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
        {
            if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
            {
                StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(targetComponent, new object[] { data }));
            }
        }

    }

    /// <summary>
    /// Calls the IEnumerator Coroutines and send a one data arg
    /// </summary>
    public void StartCoroutine<T>(GameObject target, string functionName, T data)
    {

        if (!target)
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
              new Type[] { typeof(T) }, null);

            // invoke IEnumerators with 1 data prarameter
            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(component, new object[] { data }));
                }
            }
        }
    }


    /// <summary>
    /// Stop the IEnumerator Coroutines 
    /// </summary>
    public void StopCoroutine(GameObject target, string functionName)
    {
        if (!target)
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);

            // invoke IEnumerators with no prarameter
            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    StopCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(component, null));
                }
            }
        }
    }

    /// <summary>
    /// Call the IEnumerator Coroutines with target component constraint
    /// </summary>
    public void StartCoroutine<T>(T target, string functionName) where T : Component
    {

        if (ReferenceEquals(target, null))
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any, new Type[0], null);

            // invoke IEnumerators with no prarameter
            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(component, null));
                }
            }
        }
    }

    /// <summary>
    /// Call the IEnumerator Coroutines with target component constraint + send a one data arg
    /// </summary>
    public void StartCoroutine<T, U>(T target, string functionName, U data) where T : Component
    {

        if (ReferenceEquals(target, null))
            return;

        Component[] getComponents = target.GetComponentsInParent<Component>();

        foreach (Component component in getComponents)
        {
            Type thisType = component.GetType();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo thisTypeMethodinfo = thisType.GetMethod(functionName, bindingFlags, null, CallingConventions.Any,
              new Type[] { typeof(U) }, null);

            // invoke IEnumerators with 1 data prarameter
            foreach (MethodInfo mInfo in thisType.GetMethods(bindingFlags))
            {
                if (mInfo.Name == functionName && mInfo == thisTypeMethodinfo)
                {
                    StartCoroutine((IEnumerator)thisTypeMethodinfo?.Invoke(component, new object[] { data }));
                }
            }
        }
    }
}
