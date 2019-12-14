using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(T).ToString());
                    singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

}
