using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    private T _instance;

    public T Instance
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
