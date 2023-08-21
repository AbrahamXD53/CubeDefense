using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Gerneric class for singleton instances
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (!instance)
                    {
                        SetupInstance();
                    }
                }
                return instance;
            }
        }
        public virtual void Awake()
        {
            RemoveDuplicates();
        }
        private static void SetupInstance()
        {
            instance = (T)FindObjectOfType(typeof(T));
            if (!instance)
            {
                GameObject gameObj = new GameObject(typeof(T).Name, typeof(T));
                DontDestroyOnLoad(gameObj);
            }
        }
        private void RemoveDuplicates()
        {
            if (!instance)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}