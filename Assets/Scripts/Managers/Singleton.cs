
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
					DontDestroyOnLoad(instance.gameObject);
				}
			}
			return instance;
		}
	}

	public virtual void Awake()
	{
		if (!instance)
		{
			instance = this as T;
			DontDestroyOnLoad(instance.gameObject);
		}
		else
		{
			Destroy(instance.gameObject);
		}
	}
}


