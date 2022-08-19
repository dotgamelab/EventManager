
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (!instance)
			{
				instance = FindObjectOfType<T>();

				if (!instance)
				{
					GameObject obj = new GameObject();
					obj.name = typeof(T).Name;
					instance = obj.AddComponent<T>();
				}
			}
			return instance;
		}
	}

	private void Awake()
	{
        if (FindObjectsOfType<T>().Length > 1)
		{
			T[] arrT = FindObjectsOfType<T>();

            for (int i = 0; i < FindObjectsOfType<T>().Length; i++)
			{
				if (i > 0)
				{
                    Destroy(arrT[i].gameObject);
				}
                else
					DontDestroyOnLoad(arrT[i].gameObject);
            }
		}
		else
		{
			instance = this as T;
			DontDestroyOnLoad(instance.gameObject);
		}
    }
}


