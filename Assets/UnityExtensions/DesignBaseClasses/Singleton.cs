using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static volatile T instance = null;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();
                if (!instance)
                {
                    Debug.LogWarning("Instance couldn't found, creating a new one");
                    instance = new GameObject("SomeSingleton").AddComponent<T>();

                }
            }
            return instance;

        }
    }
}
